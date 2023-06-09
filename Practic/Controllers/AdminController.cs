using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practic.Data;
using Practic.Data.Interfaces;
using Practic.Data.Models;
using Practic.Data.Repository;
using Practic.ViewModels;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Practic.Controllers
{
    [Authorize]
    public class AdminController: Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAllAims _aimRepository;
        public AdminController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IAllAims aimRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _aimRepository = aimRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }

        [Authorize(Policy = "User")]
        public IActionResult User()
        {
            var homeAimAvaliable = new HomeViewModel()
            {
                unavaliableAims = _aimRepository.GetUnavaliableAims
            };
            return View(homeAimAvaliable);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var users = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if(users == null)
            {
                ModelState.AddModelError("", "Пользователь не найден");
                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(users, loginViewModel.Password, true, false);
            if(result.Succeeded)
            {
                return Redirect(loginViewModel.ReturnUrl);
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
