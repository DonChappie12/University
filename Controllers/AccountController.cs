using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            // Erases cookie if any cookie is present
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(user);
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Registrate(ValidateUser user)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User { UserName = user.Email, Email = user.Email};

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if(result.Succeeded)
                {
                    // var _admin = await _userManager.FindByEmailAsync("admin@admin.com");
                    // if (_admin == null)
                    // {
                    //     var admin = new User
                    //     {
                    //         UserName = "admin@admin.com",
                    //         Email = "admin@admin.com"
                    //     };

                    //     var createAdmin = await _userManager.CreateAsync(admin, "Admin2019!");
                    //     if (createAdmin.Succeeded)
                    //         await _userManager.AddToRoleAsync(admin, "Admin");
                    // }

                    // var _teacher = await _userManager.FindByEmailAsync("teacher@teacher.com");
                    // if (_teacher == null)
                    // {
                    //     var teacher = new User
                    //     {
                    //         UserName = "teacher@teacher.com",
                    //         Email = "teacher@teacher.com"
                    //     };

                    //     var createTeacher = await _userManager.CreateAsync(teacher, "Teacher2019!");
                    //     if (createTeacher.Succeeded)
                    //         await _userManager.AddToRoleAsync(teacher, "Teacher");
                    // }
                    // This will create a student automatically
                    await _userManager.AddToRoleAsync(newUser, "Student");
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Register");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewData["RetrunUrl"] = returnUrl;
            return View();
        }
    }
}