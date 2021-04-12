using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagerStudent.Models;
using Microsoft.AspNetCore.Http;
using ManagerStudent.Fillter;
using ManagerStudent.Models.IRepository;

namespace ManagerStudent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _tbStudent;
        public HomeController(IStudentRepository tbStudent){
            _tbStudent = tbStudent;
        }
        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        public IActionResult Index()
        {
            Student s;
            string ss1 = HttpContext.Session.GetString("ss1");

            foreach (var item in _tbStudent.GetAllStudent())
            {
                if (item.UserName == ss1)
                {
                    s = item;
                    return View(s);
                }
            }
            return View();
        }
        [Author(true)]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [Author(true)]
        public IActionResult See()
        {
            return View(_tbStudent.GetAllStudent());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Author(true)]
        [HttpPost]
        public IActionResult Create(string UserName, string password, Boolean isAdmin)
        {
            Random rd = new Random();
            string Id = rd.Next(1, 10000).ToString();
            Student student = new Student(Id, UserName, password, isAdmin);
            Console.WriteLine(student);
            _tbStudent.CreateStudent(student);
            return Redirect("/Home/See");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            foreach (var item in _tbStudent.GetAllStudent())
            {
                if (item.UserName == email && item.Password == password)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    HttpContext.Session.SetString("ss1", item.UserName);
                    return Redirect("/Home/Index");
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
