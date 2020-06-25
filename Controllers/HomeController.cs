using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Registrate(ValidateUser user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<ValidateUser> Hasher = new PasswordHasher<ValidateUser>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };

                _context.Add(newUser);
                _context.SaveChanges();

                User findUser = _context.User.Find(newUser.UserId);
                if(findUser.UserId == 1)
                {
                    findUser.Role = "admin";
                }
                else
                {
                    findUser.Role = "student";
                }
                _context.SaveChanges();

                HttpContext.Session.SetInt32("user_id",findUser.UserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Registration");
            }
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult LoginIn(string Email, string Password)
        {
            var user = _context.User.Where(u=> u.Email == Email).FirstOrDefault();
            if(user != null && Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password))
                {
                    HttpContext.Session.SetInt32("user_id", user.UserId);
                    return RedirectToAction("About");
                }
            }
            ViewBag.error="Email and/or Password dont match";
            return View("Login");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
