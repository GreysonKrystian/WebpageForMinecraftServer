using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MinecraftServerWeb.Areas.Identity.Pages.Account;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.ViewModels;

namespace MinecraftServerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _homeLogger;
        private readonly ILogger<LoginModel> _loginLogger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork, SignInManager<IdentityUser> signInManager)
        {
            _homeLogger = loggerFactory.CreateLogger<HomeController>();
            _loginLogger = loggerFactory.CreateLogger<LoginModel>();
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        private async Task<LoginModel> ConfigureLoginModel()
        {
            LoginModel loginModel = new();
            if (!string.IsNullOrEmpty(loginModel.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, loginModel.ErrorMessage);
            }

            loginModel.ReturnUrl = "~/";

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            loginModel.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return loginModel;
        }

        public async Task<IActionResult> Index(int pageId=1)
        {
            if (pageId < 1)
            {
                return BadRequest();
            }
            IndexViewModel viewModel = new();
            var announcements = _unitOfWork.Announcement.GetAll();
            announcements = announcements.OrderByDescending(e => e.DateCreated);

            viewModel.Announcements = announcements; 
            viewModel.Users = _unitOfWork.User.GetAll();
            viewModel.LoginModel = await ConfigureLoginModel();
            viewModel.PageId = pageId;
            viewModel.Comments = _unitOfWork.Comment.GetAll();
            return View(viewModel);
        }

        public IActionResult Rules()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}