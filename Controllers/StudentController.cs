using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private UserContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public StudentController(UserContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult StudentDashboard()
        {
            return View();
        }
        public IActionResult CheckAssignments()
        {
            return View();
        }
        public IActionResult CheckGrade()
        {
            return View();
        }
        public IActionResult Classes()
        {
            return View();
        }
    }
}