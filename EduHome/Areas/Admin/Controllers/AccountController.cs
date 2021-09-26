using EduHome.DataContext;
using EduHome.Helpers.Enums;
using EduHome.Models.Entity;
using EduHome.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly EduhomeDbContext _db;
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }
        public RoleManager<IdentityRole> _userRole { get; }
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> userRole)
        {
            _userManager = userManager;
            _userRole = userRole;
            //_signInManager = signInManager;
            //_db = db;
        }
        public IActionResult Register()
        {
            AdminRegisterVM admin = new AdminRegisterVM();
            admin.Roles = new List<RoleVM>();

            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                admin.Roles.Add(new RoleVM { Name = role});
            }
            return View(admin);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(AdminRegisterVM register)
        {
            AdminRegisterVM admin = new AdminRegisterVM();
            admin.Roles = new List<RoleVM>();

            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                admin.Roles.Add(new RoleVM { Name = role });
            }

            if (!ModelState.IsValid)
            {
                return View(admin);
            }

            AppUser user = new AppUser
            {
                Fullname = register.FullName,
                UserName = register.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                   
                }
                return View(admin);       
             }
            await _userManager.AddToRoleAsync(user, register.Role);
           
            return RedirectToAction(nameof(Index), register);
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(login);
        //    }

        //    var user = await _userManager.FindByNameAsync(login.Username);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Username or Password is not correct");
        //    }
        //    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Username or Password is not correct");
        //        return View(login);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        //public async Task<IActionResult> LogOutAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction(nameof(Index), nameof(HomeController));
        //}
    }
}
