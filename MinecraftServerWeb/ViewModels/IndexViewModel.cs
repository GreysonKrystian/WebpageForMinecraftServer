using MinecraftServerWeb.Areas.Identity.Pages.Account;
using MinecraftServerWeb.Models;
#pragma warning disable CS8618
namespace MinecraftServerWeb.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Announcement> Announcements { get; set; }
        public IEnumerable<User> Users { get; set; }  


        public LoginModel LoginModel { get; set; }

        public int PageId { get; set; }

        public int? AnnouncementToExpandId { get; set; }
    }
}
