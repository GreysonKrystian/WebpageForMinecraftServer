namespace MinecraftServerWeb.Models
{

    public class Post
    {
        public int PostId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }


    }
}
