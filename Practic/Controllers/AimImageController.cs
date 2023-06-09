using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practic.Data;
using Practic.Data.Models;

namespace Practic.Controllers
{
    public class AimImageController: Controller
    {
        AppDBContent _appDBContent;
        IWebHostEnvironment _environment;
        public AimImageController(AppDBContent appDBContent, IWebHostEnvironment environment)
        {
            _appDBContent = appDBContent;
            _environment = environment;
        }

        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImageAsync(IFormFile formFile)
        {
            if(formFile != null)
            {
                string path = "/img/" + formFile.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                AimImage aimImage = new AimImage { Name = formFile.FileName, Path = path };
                _appDBContent.AimImages.Add(aimImage);
                _appDBContent.SaveChanges();
            }
            return Redirect("/AddAim/Adder");
        }

    }
}
