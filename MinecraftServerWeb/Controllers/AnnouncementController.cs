using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Utility;

namespace MinecraftServerWeb.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            return View();
        }

        // GET: Announcement/Details/5
        public ActionResult Details(int id)
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
        public async Task<ActionResult> Create(Post post)
        {
            var dcHook = new DiscordHookHandler("/1001169324494569492/3JmGCyaAsTiENcHC5vsvWFYW0TamlOk6MPjWURX3OK8PUWS5znJue7hI-yj219fO4Jvx");
            await dcHook.CreateDiscordMessage(post);
            try
            {
                return RedirectToAction(nameof(Index),"Home");
            }
            catch
            {
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
