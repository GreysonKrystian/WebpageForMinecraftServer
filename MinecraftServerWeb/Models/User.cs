using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8618
namespace MinecraftServerWeb.Models
{
    public class User : IdentityUser
    {
        public string? ServerNickname { get; set; }
        public string ForumNickname { get; set; }
        public DateTime DateCreated { get; set; }
        public string Rank { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public string? LockReason { get; set; }
        public string? MuteReason { get; set; }
        public bool IsMuted { get; set; }
        public DateTime? MuteEndDate { get; set; }
        public string? ProfileDescription { get; set; }

    }
}
