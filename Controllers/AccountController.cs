using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
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
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

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

        [HttpPost("register")]
        public async Task<IActionResult> Registrate(ValidateUser user)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User { UserName = user.Email, Email = user.Email};

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Register");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}