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
                    var userEmail = await _userManager.FindByEmailAsync(user.Email);
                    var roles = await _userManager.GetRolesAsync(userEmail);
                    
                    if(roles.Contains("Admin"))
                        return RedirectToAction("AdminDashboard", "Admin");
                    else if(roles.Contains("Teacher"))
                        return RedirectToAction("TeacherDashboard", "Teacher");
                    else
                        return RedirectToAction("StudentDashboard", "Student");
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