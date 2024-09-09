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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTask>()
                .HasOne(x => x.UserProfile)
                .WithMany(x => x.UserTasks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserBigTask> UserBigTask { get; set; }
        public DbSet<UserImage> UserImage { get; set; }
        public DbSet<UserMessage> UserMessage { get; set; }
        public DbSet<UserPost> UserPost { get; set; }
        public DbSet<UserTask> UserTask { get; set; }

    }
}
