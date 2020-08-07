using System.Collections.Generic;
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
            // ViewBag.info = users;
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
        [Route("delete/{Id:guid}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            // *** Finds user by Id ***
            var deleteUser = await _userManager.FindByIdAsync(Id);
            // *** Finds roles associated with user ***
            var rolesFromUser = await _userManager.GetRolesAsync(deleteUser);
            if(deleteUser != null)
            {
                // *** Checks for roles ***
                if( rolesFromUser.Count > 0)
                {
                    foreach(var role in rolesFromUser)
                    {
                        // *** Removes user from any roles ***
                        var remove  = await _userManager.RemoveFromRoleAsync(deleteUser, role);
                    }
                }
                // *** Finally deletes user ***
                var result = await _userManager.DeleteAsync(deleteUser);
                if(result.Succeeded)
                    return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("AdminDashboard");
        }
    }
}