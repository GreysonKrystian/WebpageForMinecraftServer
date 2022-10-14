using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels;

public class CreateAnnouncementViewModel
{
    public Announcement Announcement { get; set; }
    public bool PostToDiscord { get; set; }
}