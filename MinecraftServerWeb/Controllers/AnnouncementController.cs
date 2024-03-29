﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;
using MinecraftServerWeb.Utility.DiscordHandlers;
using MinecraftServerWeb.ViewModels;

namespace MinecraftServerWeb.Controllers
{
    [Authorize(Roles= SD.RoleOwner + ", " + SD.RoleAdmin)]
    public class AnnouncementController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        
        public AnnouncementController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration;
        }


        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAnnouncementViewModel announcementViewModel)
        {
            try
            {
                announcementViewModel.Announcement.AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (announcementViewModel.PostToDiscord)
                {
                    var dcHook = new DiscordHookHandler(_userManager, _configuration);
                    await dcHook.SendDiscordEmbeddedMessage(announcementViewModel.Announcement);
                }
                else
                {
                    _logger.LogInformation("Announcement was not sent to discord");
                }
                _unitOfWork.Announcement.Add(announcementViewModel.Announcement);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index),"Home");
            }
            catch
            {
                _logger.LogError("Failed to create announcement");
                return View();
            }
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

            CreateAnnouncementViewModel createAnnouncementViewModel = new CreateAnnouncementViewModel
            {
                Announcement = post,
                PostToDiscord = false
            };
            return View(createAnnouncementViewModel);
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Announcement/Edit/{PostId}")]

        public async Task<ActionResult> Edit(CreateAnnouncementViewModel createAnnouncementViewModel)
        {
            try
            {
                createAnnouncementViewModel.Announcement.DateCreated = DateTime.Now;
                _unitOfWork.Announcement.Update(createAnnouncementViewModel.Announcement);
                if (createAnnouncementViewModel.PostToDiscord)
                {
                    var dcHook = new DiscordHookHandler(_userManager, _configuration);
                    await dcHook.SendDiscordEmbeddedMessage(createAnnouncementViewModel.Announcement);
                }
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
