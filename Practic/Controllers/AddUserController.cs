using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practic.Data.Models;
using Practic.ViewModels;
using System.Security.Claims;

namespace Practic.Controllers
{
    public class AddUserController: Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUser applicationUser;
        public AddUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                applicationUser = new ApplicationUser { 
                    UserName = registerViewModel.UserName, 
                    Password = registerViewModel.Password,
                    Name = registerViewModel.Name,
                    Surname = registerViewModel.Surname
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(applicationUser, registerViewModel.Password);
                
                if (result.Succeeded)
                {
                    if(applicationUser.UserName.Contains("Admin") || applicationUser.UserName.Contains("admin"))
                    {
                        await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Role, "Administrator"));
                    }
                    else
                    {
                        await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Role, "User"));
                    }
                    // установка куки
                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
    }
}
