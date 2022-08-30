using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class CommentViewModel
    {
        public User CommentAuthor { get; set; }
        public Comment Comment { get; set; }

    }
}
