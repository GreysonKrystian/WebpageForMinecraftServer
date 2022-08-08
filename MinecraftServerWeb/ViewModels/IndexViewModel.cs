using MinecraftServerWeb.Areas.Identity.Pages.Account;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Announcement>? Announcements { get; set; }
        public IEnumerable<User>? Users { get; set; }  

        public LoginModel LoginModel { get; set; }
    }
}
