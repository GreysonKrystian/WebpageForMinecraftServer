#pragma warning disable CS8618
namespace MinecraftServerWeb.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string Nickname { get; set; }
        public DateTime DateCreated { get; set; }
        public string Rank { get; set; } 
        public string AvatarUrl { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
