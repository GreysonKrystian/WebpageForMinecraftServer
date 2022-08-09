using Microsoft.AspNetCore.Identity;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class AnnouncementViewModel
    {
        public Announcement Announcement { get; set; }

        public UserManager<IdentityUser> UserManager { get; set; }
    }
}
