using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<User> Users { get; set; }  
    }
}
