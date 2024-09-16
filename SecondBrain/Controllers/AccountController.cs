using Microsoft.AspNetCore.Mvc;
using SecondBrain.DTOs.Account;
using SecondBrain.Interfaces;

namespace SecondBrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _IAccount;

        public AccountController(IAccount IAccount)
        {
            _IAccount = IAccount;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(Register model)
        {
            await _IAccount.Register(model, this.Request.Method, ModelState.IsValid);
            return View();
        }

        public async Task<IActionResult> SignIn(SignIn model)
        {
            var result = await _IAccount.SignIn(model, ModelState.IsValid);
            CookieOptions opt = new CookieOptions();
            opt.Expires = DateTimeOffset.Now.AddYears(1);
            opt.HttpOnly = true;
            Response.Cookies.Append("UserId", result, opt);
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            var result = _IAccount.Logout();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return Redirect("/");
        }
    }
}
