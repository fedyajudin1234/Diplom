using Microsoft.AspNetCore.Mvc;
using Practic.Data.Models;
using Practic.Data;
using Practic.Data.Interfaces;
using Practic.ViewModels;

namespace Practic.Controllers
{
    public class CompilerController: Controller
    {
        private readonly IAllCompilers allCompilers;
        private readonly AimMaker aimMaker;

        public CompilerController(IAllCompilers allCompilers, AimMaker aimMaker)
        {
            this.allCompilers = allCompilers;
            this.aimMaker = aimMaker;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
