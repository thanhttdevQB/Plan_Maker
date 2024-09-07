using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Areas.Identity.Data;

namespace SecondBrain.Areas.Identity.Data;

public class SecondBrainContext : IdentityDbContext<SecondBrainUser>
{
    public SecondBrainContext(DbContextOptions<SecondBrainContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
