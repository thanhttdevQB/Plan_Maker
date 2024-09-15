using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.DTOs;
using SecondBrain.Models;
using SecondBrain.Data;
using Microsoft.EntityFrameworkCore;

namespace SecondBrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SecondBrainDataContext _context;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, SecondBrainDataContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(Register model)
        {
            if (string.Equals(this.Request.Method,"POST", StringComparison.OrdinalIgnoreCase))
            {
                if (ModelState.IsValid)
                {
                    AppUser newUser = new()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Name = model.Name
                    };
                    var result = await _userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser, false);
                        await _context.UserProfile.AddAsync(new UserProfile
                        {
                            IsSuspend = false,
                            UserAccount = _context.Users.Where(x => x.Email == newUser.Email).FirstOrDefault(),
                        });
                        _context.SaveChanges();
                        return Redirect("/");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        Console.WriteLine(error);
                    }
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> SignIn(SignIn model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    UserProfile User = _context.UserProfile.Include(x => x.UserAccount).Where(x => x.UserAccount.Email == model.Email).FirstOrDefault();
                    CookieOptions opt = new CookieOptions();
                    opt.Expires = DateTimeOffset.Now.AddYears(1);
                    opt.HttpOnly = true;
                    Response.Cookies.Append("UserId", User.Id.ToString(), opt);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Email or password");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(SignIn model)
        {
            var result = _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
