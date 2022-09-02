using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;

namespace MinecraftServerWeb.Controllers
{
    [Authorize(Roles= SD.RoleOwner + ", " + SD.RoleAdmin)] 
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public IActionResult ManageUsers()
        {
            var users = _unitOfWork.User.GetAll();
            return View(users);
        }

        [Route("/{accountId}")]
        public IActionResult MuteAccountManager(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            return View(user);
        }

        [Route("/{accountId}")]
        public IActionResult BlockAccountManager(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            return View(user);
        }

    [Route("Admin/AccountInfo/{accountId}")]
        public IActionResult AccountInfo(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            return View(user);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MuteAccountManager(User user)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlockAccountManager(User user)
        {
        }*/

        #region API CALLS

        // GET: Admin/GetAllUsers/
        [HttpGet]
        [Route("Admin/GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            IEnumerable<User> users = _unitOfWork.User.GetAll();
            return Json(new {data = users});
        }
        #endregion
    }
}
