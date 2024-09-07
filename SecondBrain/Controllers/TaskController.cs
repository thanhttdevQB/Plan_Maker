using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Data;
using SecondBrain.Models;

namespace SecondBrain.Controllers
{
    public class TaskController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly SecondBrainDataContext _context;

        public IActionResult CheckAndReturnLogin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/SignIn");
            }
            return null;
        }

        public IActionResult Index()
        {
            CheckAndReturnLogin();
            return View();
        }

        public IActionResult AddTask(UserTask model)
        {
            CheckAndReturnLogin();
            if (ModelState.IsValid)
            {
                UserTask task = new UserTask()
                {
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Name = model.Name,
                };
                _context.Tasks.Add(model);
            }
            return View("Home/Index");
        }
    }
}
