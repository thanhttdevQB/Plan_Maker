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
        public readonly IUserTask _IUserTask; 
        public readonly IAccount _IAccount;

        public HomeController(IUserTask IUserTask, IAccount IAccount)
        {
            _IUserTask = IUserTask;
            _IAccount = IAccount;
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

        public async Task<IActionResult> GetTaskByUserId()
        {
            try
            {
                string UserId = Request.Cookies.Where(x => x.Key == "UserId").FirstOrDefault().Value;
                var allTask = await _IUserTask.GetAllTaskByUserId(Guid.Parse(UserId));
                List<UserTaskReadUpdateDTO> result = allTask;
                ViewBag.AllTask = result;
                return View();
            } catch
            {
                AccountController newAccountController = new AccountController(_IAccount);
                return newAccountController.View();
            }
        }

        public async Task<IActionResult> UpdateTask(UserTaskCreateDTO NewUserTask)
        {
            CheckAndReturnLogin();

            string UserId = Request.Cookies.Where(x => x.Key == "UserId").FirstOrDefault().Value;
            NewUserTask.UserId = Guid.Parse(UserId);

            await _IUserTask.UpdateTask(NewUserTask);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTask(UserTaskCreateDTO NewUserTask)
        {
            CheckAndReturnLogin();

            await _IUserTask.DeleteTask(NewUserTask.Status);

            return RedirectToAction("Index");
        }

        public ActionResult FormSuccess()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            CheckAndReturnLogin();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
