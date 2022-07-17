namespace MinecraftServerWeb.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string Content { get; set; }

    }
}
