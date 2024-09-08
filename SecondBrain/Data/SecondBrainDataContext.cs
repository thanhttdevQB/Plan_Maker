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

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserBigTask> UserBigTask { get; set; }
        public DbSet<UserImage> UserImage { get; set; }
        public DbSet<UserMessage> UserMessage { get; set; }
        public DbSet<UserPost> UserPost { get; set; }
        public DbSet<UserTask> UserTask { get; set; }

    }
}
