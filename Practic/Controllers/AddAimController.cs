using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practic.Data;
using Practic.Data.Models;
using Practic.ViewModels;

namespace Practic.Controllers
{
    public class AddAimController: Controller
    {
        private readonly AppDBContent _appDBContent;
        public AddAimController(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        [HttpGet]
        public IActionResult Adder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdderAsync(AddAimViewModel addAimViewModel)
        {
            var applicationUserId = _appDBContent.Users.Select(user => user.Id).FirstOrDefault();
            Aim aim = new Aim
            {
                Name = addAimViewModel.Name,
                TextField = addAimViewModel.TextField,
                AimTextField = addAimViewModel.AimTextField,
                Image = addAimViewModel.Image,
                Avaliable = addAimViewModel.Avaliable = true,
                category = addAimViewModel.category,
                ApplicationUserId = applicationUserId
            };
            if(aim.category.CategoryName.Equals("Первая часть"))
            {
                aim.category.Description = "Ознакомление с языкос программирования C#";
            }
            else if(aim.category.CategoryName.Equals("Вторая часть"))
            {
                aim.category.Description = "Изучение классов в языке C#";
            }
            _appDBContent.Add(aim);
            await _appDBContent.SaveChangesAsync();
            return Redirect("/Home/Index");
        }
    }
}
