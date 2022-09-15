// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;

        public new User User { get; set; }
        public LockoutModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string? email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            User = (User)await _userManager.FindByEmailAsync(email);
            if (User == null)
            {
                throw new InvalidOperationException($"Unable to load user.");
            }

            if (!_userManager.IsLockedOutAsync(User).GetAwaiter().GetResult())
            {
                return BadRequest("This user is not locked");
            }
            return Page();
        }
    }
}
