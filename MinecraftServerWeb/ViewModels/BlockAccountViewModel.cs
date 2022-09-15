using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class BlockAccountViewModel
    {
        public User User { get; set; }
        public string BlockEndDate { get; set; }

        public string BlockEndTime { get; set; }

        public string userId { get; set; }

        public string BanReason { get; set; }

    }
}
