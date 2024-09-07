using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Data;
using SecondBrain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 
builder.Services.AddDbContext<SecondBrainDataContext>(
        opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );

builder.Services.AddIdentity<AppUser, IdentityRole>(
    opts =>
    {
        opts.Password.RequiredUniqueChars = 0;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequiredLength = 8;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireLowercase = false;
    }
    )
    .AddEntityFrameworkStores<SecondBrainDataContext>()
            .AddSignInManager()
            .AddRoles<IdentityRole>()
            .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.cd 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
