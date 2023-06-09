using Microsoft.AspNetCore.Mvc;
using Practic.Data.Interfaces;
using Practic.Data.Models;
using Practic.ViewModels;

namespace Practic.Controllers
{
    public class AimsController: Controller
    {
        private readonly IAllAims allAims;
        private readonly IAimCategory aimCategory;
        public AimsController(IAllAims _allAims, IAimCategory _aimCategory)
        {
            allAims = _allAims;
            aimCategory = _aimCategory;
        }
        [Route("Aims/List")]
        [Route("Aims/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Aim> aims = null;
            string currentCategory = category;
            if (string.IsNullOrEmpty(currentCategory))
            {
                aims = allAims.Aims.OrderBy(obj => obj.Id);
            }
            else
            {
                if(string.Equals("first", category, StringComparison.OrdinalIgnoreCase))
                {
                    aims = allAims.Aims.Where(obj => obj.category.CategoryName.Equals("Первая часть")).OrderBy(obj => obj.Id);
                    currentCategory = "Первая часть";
                }
                else if (string.Equals("second", category, StringComparison.OrdinalIgnoreCase))
                {
                    aims = allAims.Aims.Where(obj => obj.category.CategoryName.Equals("Вторая часть")).OrderBy(obj => obj.Id);
                    currentCategory = "Вторая часть";
                }
            }
            var aimObject = new AimListViewModel
            {
                getAllAims = aims,
                currentCategory = category,
            };
            ViewBag.Title = "Main page";
            return View(aimObject);
        }
    }
}
