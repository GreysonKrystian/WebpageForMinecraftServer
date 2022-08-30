using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;
using MinecraftServerWeb.ViewModels;

namespace MinecraftServerWeb.Controllers
{
    [Authorize(Roles= SD.RoleOwner + ", " + SD.RoleAdmin)]
    public class AnnouncementController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public AnnouncementController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Announcement announcement)
        {
            announcement.AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dcHook = new DiscordHookHandler("/1001169324494569492/3JmGCyaAsTiENcHC5vsvWFYW0TamlOk6MPjWURX3OK8PUWS5znJue7hI-yj219fO4Jvx", _userManager); // TODO make this environmental
            await dcHook.SendDiscordEmbeddedMessage(announcement);

            _unitOfWork.Announcement.Add(announcement); // TODO exception handling
            _unitOfWork.Commit();

            try
            {
                return RedirectToAction(nameof(Index),"Home");
            }
            catch
            {
                _logger.LogError("Failed to send announcement to Discord/create announcement");
                return View();
            }
        }
        // POST: Announcement/AddComment/
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int announcementId, string content)
        {
            if (content == null)
            {
                return BadRequest();
            }
            if (null == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            Comment comment = new()
            {
                AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Content = content,
                PostId = announcementId
            };
            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Commit();
            return new AcceptedResult();
        }
        // GET: Announcement/Edit/5
        [Route("Announcement/Edit/{announcementId}")]
        public ActionResult Edit(int announcementId)
        {
            Announcement? post = _unitOfWork.Announcement.GetFirstOrDefault(e => e.PostId == announcementId);
            if (post is null)
            {
                return BadRequest();
            }
            if (post.AuthorId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            return View(post);
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Announcement announcement)
        {
            try
            {
                announcement.DateCreated = DateTime.Now;
                _unitOfWork.Announcement.Update(announcement);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index), controllerName:"Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Details/5
        [AllowAnonymous]
        public ActionResult Details(int announcementId)
        {
            Announcement announcement = _unitOfWork.Announcement.GetFirstOrDefault(e => e.PostId == announcementId);
            var comments = _unitOfWork.Comment.GetAll();
            var users = _unitOfWork.User.GetAll();
            AnnouncementViewModel announcementViewModel = new AnnouncementViewModel
            {
                Announcement = announcement,
                Comments = comments,
                Users = users
            };
            return View(announcementViewModel);
        }

        #region API CALLS
            
        // GET: Announcement/GetAnnouncement/5
        [Route("Announcement/GetAnnouncement/{announcementId}")]
        public ActionResult GetAnnouncement(int announcementId)
        {
            Announcement? post = _unitOfWork.Announcement.GetFirstOrDefault(e => e.PostId == announcementId);
            return Json(new {data = post});
        }

        // DELETE: Announcement/Delete/5
        [HttpDelete("Announcement/Delete/{announcementId:int}")]
        [ValidateAntiForgeryToken]
        [Route("Announcement/Delete/{announcementId:int}")]
        public ActionResult Delete(int announcementId)
        {
            Announcement? post = _unitOfWork.Announcement.GetFirstOrDefault(e => e.PostId == announcementId);
            string userId = _userManager.GetUserId(User);
            if(userId != post.AuthorId)
            {
                return Unauthorized();
            }
            if (post == null)
            {
                return Json(new { success = false, message = "Cannot delete this announcement." });
            }
            _unitOfWork.Announcement.Remove(post);
            _unitOfWork.Commit();
            return Json(new { success = true, message = "Successful delete of the announcement." });
        }
        
        #endregion
    }
}
