using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Models;

namespace SecondBrain.Data
{
    public class SecondBrainDataContext : IdentityDbContext<AppUser>
    {
        public SecondBrainDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BigTask> BigTasks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
    }
}
