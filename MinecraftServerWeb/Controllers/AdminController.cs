using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;
using MinecraftServerWeb.Utility.Blockade;
using MinecraftServerWeb.ViewModels;

namespace MinecraftServerWeb.Controllers
{
    [Authorize(Roles= SD.RoleOwner + ", " + SD.RoleAdmin)] 
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
                _unitOfWork = unitOfWork;
                _userManager = userManager;
        }
        public IActionResult ManageUsers()
        {
            var users = _unitOfWork.User.GetAll();
            return View(users);
        }

        [Route("/Admin/MuteAccountManager/{accountId}")]
        public IActionResult MuteAccountManager(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            return View(user);
        }

        [Route("/Admin/BlockAccountManager/{accountId}")]
        public IActionResult BlockAccountManager(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            BlockAccountViewModel blockAccountViewModel= new();
            blockAccountViewModel.User = user;
            return View(blockAccountViewModel);
        }

        [Route("Admin/AccountInfo/{accountId}")]
        public IActionResult AccountInfo(string accountId)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(e => e.Id == accountId);
            if (user == null)
                return BadRequest();
            return View(user);
        }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult MuteAccountManager(User user)
          {
              throw new NotImplementedException();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          [Route("/Admin/BlockAccountManager/{accountId}")]
          public IActionResult BlockAccountManager(BlockAccountViewModel blockAccountViewModel)
          {
              if (string.IsNullOrEmpty(blockAccountViewModel.BlockEndDate))
              {
                  return BadRequest("Wrong date format");
              }
              if(string.IsNullOrEmpty(blockAccountViewModel.BlockEndDate) ||
                 !TimeSpan.TryParse(blockAccountViewModel.BlockEndTime, out _) ||
                  TimeSpan.FromHours(24) < TimeSpan.Parse(blockAccountViewModel.BlockEndTime))
              {
                  return BadRequest("Wrong hour format");
              }
              DateTime BanEndDate = DateTime.Parse(blockAccountViewModel.BlockEndDate);
              TimeSpan BanEndTime = TimeSpan.Parse(blockAccountViewModel.BlockEndTime);
              BanEndDate = BanEndDate.Add(BanEndTime);
              if (BanEndDate < DateTime.Now)
              {
                  return BadRequest("Wrong Date");
              }
              LockUserHandler lockUserHandler = new(_userManager, _unitOfWork);
              bool success = lockUserHandler.TimeLock(blockAccountViewModel.userId, BanEndDate, blockAccountViewModel.BanReason);
              if (!success)
              {
                  return BadRequest();
              }
              return RedirectToAction(nameof(Index), "Home");
              
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          [Route("/Admin/UnblockAccount/{userId}")]
          public IActionResult UnblockAccount(string userId)
          {
              if (userId == null) throw new ArgumentNullException(nameof(userId));
              LockUserHandler lockUserHandler = new(_userManager, _unitOfWork);
              lockUserHandler.Unlock(userId);
              return new AcceptedResult();
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
