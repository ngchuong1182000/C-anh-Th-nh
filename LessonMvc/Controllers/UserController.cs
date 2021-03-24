using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LessonMvc.Models;

namespace LessonMvc.Controllers
{
    public class UserController : Controller
    {
        public List<Person> listPerson = new List<Person>();
        public IActionResult Index()
        {
            Person student = new Person("Chu Nguyên ", "Chương", "male", new DateTime(2000, 11, 08), 0987374741, "bac giang", true);
            listPerson.Add(student);
            return View(listPerson);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person user)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Console.WriteLine(user.firstName);
                message = "product " + user.firstName + " Rate " + user.lastName + " With Rating created successfully";
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Content(message);
        }
    }
}