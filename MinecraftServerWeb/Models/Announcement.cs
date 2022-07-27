namespace MinecraftServerWeb.Models
{
    public class Announcement : Post
    {
        public bool IsEmbedded { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

    }
}
