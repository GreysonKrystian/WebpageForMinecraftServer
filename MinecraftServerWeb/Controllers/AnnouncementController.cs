using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;

namespace MinecraftServerWeb.Controllers
{
    [Authorize(Roles= SD.RoleOwner)]
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
        // GET: Announcement
        public ActionResult Index()
        {
            return View();
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
            announcement.Author = (User)_userManager.FindByIdAsync(announcement.AuthorId).GetAwaiter().GetResult(); // TODO automate (not by ID)

            var dcHook = new DiscordHookHandler("/1001169324494569492/3JmGCyaAsTiENcHC5vsvWFYW0TamlOk6MPjWURX3OK8PUWS5znJue7hI-yj219fO4Jvx"); // TODO make this environmental
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

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
