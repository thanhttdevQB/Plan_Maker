using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.DTO;

namespace SecondBrain.Controllers
{
    public class AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Register1(Register model)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Register2(Register model)
        //{
        //    return View();
        //}
        public async Task<IActionResult> Register(Register model)
        {
            if (string.Equals(this.Request.Method,"POST", StringComparison.OrdinalIgnoreCase))
            {

                if (ModelState.IsValid)
                {
                    AppUser newUser = new()
                    {
                        Email = model.Email,
                        UserName = model.Name,
                        Name = model.Name
                    };
                    var result = await userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(newUser, false);

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
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
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
            var result = signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
