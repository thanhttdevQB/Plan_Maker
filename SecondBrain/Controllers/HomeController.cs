using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using SecondBrain.Data;
using SecondBrain.DTOs.Task;
using SecondBrain.Interfaces;
using SecondBrain.Models;
using System.Diagnostics;


namespace SecondBrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _SignInManager;
        public readonly IUserTask _IUserTask;

        public HomeController(IUserTask IUserTask, SignInManager<AppUser> SignInManager)
        {
            _SignInManager = SignInManager;
            _IUserTask = IUserTask;
        }

        public IActionResult CheckAndReturnLogin()
        {
            if (!User.Identity.IsAuthenticated || Request.Cookies.Where(x => x.Key == "UserId").FirstOrDefault().Value == null)
            {
                Response.Redirect("/Account/SignIn");
            }
            return null;
        }

        public async Task<IActionResult> Index()
        {
            CheckAndReturnLogin();

            await GetTaskByUserId();

            return View();
        }

        public IActionResult Privacy()
        {
            CheckAndReturnLogin();

            return View();
        }

        public async Task<IActionResult> AddTask(UserTaskCreateDTO NewUserTask)
        {
            CheckAndReturnLogin();

            string UserId = Request.Cookies.Where(x => x.Key == "UserId").FirstOrDefault().Value;
            NewUserTask.UserId = Guid.Parse(UserId);
            var result = await _IUserTask.AddTask(NewUserTask);
            await GetTaskByUserId();
            return View("Index");
        }

        public async Task GetTaskByUserId()
        {
            try
            {
                string UserId = Request.Cookies.Where(x => x.Key == "UserId").FirstOrDefault().Value;
                var allTask = await _IUserTask.GetAllTaskByUserId(Guid.Parse(UserId));
                List<UserTaskReadUpdateDTO> result = allTask;
                ViewBag.AllTask = result;
            } catch
            {
                Response.Redirect("/Account/SignIn");
            }
        }

        public IActionResult UpdateTask(UserTaskReadUpdateDTO NewUserTask)
        {
            CheckAndReturnLogin();

            var result = _IUserTask.UpdateTask(NewUserTask);

            return View("Home/Index");
        }

        public IActionResult DeleteTask(Guid TaskId)
        {
            CheckAndReturnLogin();

            var result = _IUserTask.DeleteTask(TaskId);

            return View("Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            CheckAndReturnLogin();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
