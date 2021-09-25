using EduHome.DataContext;
using EduHome.Helpers;
using EduHome.Models.Entity;
using EduHome.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AccountController: Controller
    {
        private readonly EduhomeDbContext _db;
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }
        public AccountController(EduhomeDbContext db,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            
            AppUser user = new AppUser
            {
                Fullname = register.FullName,
                UserName = register.Username,
                Email = register.Email,                
            };
           
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(register);
            }
            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
            //EmailHelper emailHelper = new EmailHelper();
            //bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

            //if (emailResponse)
            //    return RedirectToAction("Index");
            //else
            //{
            //    // log email failed 
            //}
            return RedirectToAction(nameof(Login), register);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is not correct");
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), nameof(HomeController));
        }
    }
}
