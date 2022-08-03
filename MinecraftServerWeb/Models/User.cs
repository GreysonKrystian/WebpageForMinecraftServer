using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8618
namespace MinecraftServerWeb.Models
{
    public class User : IdentityUser
    {

        public int UserId { get; set; }
        public string ServerNickname { get; set; }
        public DateTime DateCreated { get; set; }
        public string Rank { get; set; } 
        public string AvatarUrl { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
