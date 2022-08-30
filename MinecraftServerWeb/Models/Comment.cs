namespace MinecraftServerWeb.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
