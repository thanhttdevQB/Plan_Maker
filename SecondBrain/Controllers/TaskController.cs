using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Data;
using SecondBrain.DTOs.Task;
using SecondBrain.Interfaces;
using SecondBrain.Models;

namespace SecondBrain.Controllers
{
    public class TaskController : Controller
    {
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly IUserTask _IUserTask;

        public TaskController(IUserTask IUserTask, SignInManager<AppUser> SignInManager)
        {
            _SignInManager = SignInManager;
            _IUserTask = IUserTask;
        }

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

        public IActionResult AddTask(UserTaskCreateDTO NewUserTask)
        {
            CheckAndReturnLogin();
            var result = _IUserTask.AddTask(NewUserTask);
            return View("Home/Index");
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

        public IActionResult GetTaskListByUserId(Guid UserId)
        {
            CheckAndReturnLogin();
            var result = _IUserTask.GetAllTaskByUserId(UserId);
            return Ok(result);
        }
    }
}
