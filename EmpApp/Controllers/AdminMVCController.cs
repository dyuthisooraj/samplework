using EmpApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpApp.Controllers
{
    public class AdminMVCController : Controller
    {
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(UserLoginMVC loginDetails)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7170");
                var postTask = client.PostAsJsonAsync("api/Admin/login", loginDetails);
                postTask.Wait();
                var Result = postTask.Result;
                if (!Result.IsSuccessStatusCode)
                {
                    return BadRequest("User wrong");
                }
                return RedirectToAction("DashBoard", "AdminMVC");
            }

            
        public IActionResult Register(UserLoginMVC user2)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7170");
                var postTask = client.PostAsJsonAsync<UserLoginMVC>("api/Admin/register", user2);
                postTask.Wait();
                var Result = postTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "AdminMVC");
                }
                return View();
            }
            public ActionResult DashBoard()
            {
                return View();
            }
            public ActionResult Logout()
            {
            return RedirectToAction("Login", "AdminMVC");
        }
    }


    }

