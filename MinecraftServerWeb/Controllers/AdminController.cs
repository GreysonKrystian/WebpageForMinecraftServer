using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Manage()
        {
            var users = _unitOfWork.User.GetAll();
            return View(users);
        }
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
