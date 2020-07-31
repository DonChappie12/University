using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult AdminDashboard(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var users = _context.Users;
            return View(users);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewUser(ValidateUser user)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User { UserName = user.Email, Email = user.Email};

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if(result.Succeeded)
                {
                    // This will create a student automatically
                    await _userManager.AddToRoleAsync(newUser, "Student");
                }
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return RedirectToAction("CreateUser");
            }
        }
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetUserDetails(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            return View(user);
        }
        public IActionResult ChangeRoles()
        {
            return View();
        }
    }
}