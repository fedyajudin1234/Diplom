using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Data.Interfaces;
using Practic.Data.Models;
using Practic.ViewModels;

namespace Practic.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllAims _aimRepository;
        public HomeController(IAllAims aimRepository)
        {
            _aimRepository = aimRepository;
        }

        [Authorize]
        public ViewResult Index()
        {
            var homeAimAvaliable = new HomeViewModel()
            {
                avaliableAims = _aimRepository.GetAvaliableAims
            };
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View(homeAimAvaliable);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult StartingPage()
        {
            return View();
        }
    }
}
