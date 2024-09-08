using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Data;
using SecondBrain.Models;
using System.Diagnostics;

namespace SecondBrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly SecondBrainDataContext _context;

        public IActionResult CheckAndReturnLogin()
        {
            if(!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/SignIn");
            }
            return null;
        }

        public HomeController(ILogger<HomeController> logger, SecondBrainDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            CheckAndReturnLogin();
            return View();
        }

        public IActionResult Privacy()
        {
            CheckAndReturnLogin();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            CheckAndReturnLogin();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> AddTask(Models.UserTask model)
        {
            CheckAndReturnLogin();
            if (ModelState.IsValid)
            {
                Models.UserTask task = new Models.UserTask()
                {
                    StartTime = model.StartTime,
                    TaskDay = model.TaskDay,
                    EndTime = model.EndTime,
                    Description = model.Description,
                    Name = model.Name,
                    Status = model.Status
                };
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
            return View("Index");
        }
    }
}
