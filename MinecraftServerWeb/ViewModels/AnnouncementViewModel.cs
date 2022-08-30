using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class AnnouncementViewModel
    {
        public Announcement Announcement { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
