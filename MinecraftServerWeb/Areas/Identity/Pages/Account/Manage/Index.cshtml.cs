// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Discord;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;

namespace MinecraftServerWeb.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public const double MaxImageSize = 2;
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Display(Name= "Nick na forum")]
        public string ForumUsername { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }

            [Display(Name= "Opis profilu (maksymalnie 1000 znaków)")]
            public string ProfileDescription { get; set; }

            public IFormFile AddedPhoto { get; set; }

        }

        private async Task LoadAsync(User user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var description = user.ProfileDescription;
            Email = email;
            ForumUsername = user.ForumNickname;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                ProfileDescription = description,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = (User)await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile getFile)
        {
            var user = (User)await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            Input.AddedPhoto = getFile;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Nieznany błąd przy ustawianiu numeru telefonu.";
                    return RedirectToPage();
                }
            }
            if (Input.ProfileDescription != user.ProfileDescription)
            {
                user.ProfileDescription = Input.ProfileDescription;
            }
            if ( Input.AddedPhoto != null)
            {
                int[] sizes = {600, 300, 100} ;
                foreach(int size in sizes)
                {
                    var btm = UserImagesManager.ResizeImage(new Size(size, size), UserImagesManager.ConvertIFormFileToImage(Input.AddedPhoto));
                    var path = UserImagesManager.GetUserImageSavePath(user.Email, _webHostEnvironment,
                        size.ToString());
                    UserImagesManager.SaveBitmapToFile(btm, path);
                }
            }
            _unitOfWork.Commit();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Twój profil został zaaktualizowany";
            return RedirectToPage();
        }
    }
}
