using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Areas.Identity.Data;

namespace SecondBrain.Areas.Identity.Data;

public class DatabaseContext : IdentityDbContext<SecondBrainUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguratuion());
    }
}

public class ApplicationUserEntityConfiguratuion : IEntityTypeConfiguration<SecondBrainUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SecondBrainUser> builder)
    {
        builder.Property(x => x.UserName).IsRequired();
    }
}