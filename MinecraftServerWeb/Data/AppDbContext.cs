using Microsoft.EntityFrameworkCore;

namespace MinecraftServerWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    }
}
