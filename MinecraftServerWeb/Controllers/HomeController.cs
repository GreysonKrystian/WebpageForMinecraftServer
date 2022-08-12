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


            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            loginModel.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return loginModel;
        }

        public async Task<IActionResult> Index(int pageId=1, int? announcementToExpandId=null)
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
            viewModel.AnnouncementToExpandId = announcementToExpandId;

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            viewModel.LoginModel.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            viewModel.LoginModel.ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(viewModel.LoginModel.Input.Email, viewModel.LoginModel.Input.Password, viewModel.LoginModel.Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _loginLogger.LogInformation("User logged in.");
                    return LocalRedirect(viewModel.LoginModel.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = viewModel.LoginModel.ReturnUrl, RememberMe = viewModel.LoginModel.Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _loginLogger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
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