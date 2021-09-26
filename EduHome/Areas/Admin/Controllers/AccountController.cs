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
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }
        public RoleManager<IdentityRole> _userRole { get; }
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> userRole, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _userRole = userRole;
            _signInManager = signInManager;
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
            //CreateAsync();

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
           
            return View(nameof(Login));
        }

        //public async Task CreateAsync()
        //{
        //    //await _userRole.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        //    await _userRole.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        //    await _userRole.CreateAsync(new IdentityRole(Roles.User.ToString()));
        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AdminLoginVM adminLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(adminLogin);
            }

            var user = await _userManager.FindByNameAsync(adminLogin.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(adminLogin);
            }
            if ((await _userManager.GetRolesAsync(user))[0] == Roles.SuperAdmin.ToString() || 
                (await _userManager.GetRolesAsync(user))[0] == Roles.Admin.ToString())
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, adminLogin.Password, false, false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username or Password is not correct");
                    return View(adminLogin);
                }
                return RedirectToAction("Index", "post");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(adminLogin);
            }
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index),"post");
        }
    }
}
