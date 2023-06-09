using Microsoft.AspNetCore.Mvc;
using Practic.Data;
using Practic.Data.Interfaces;
using Practic.Data.Models;
using Practic.Data.Repository;
using Practic.ViewModels;
using System.Xml.Linq;

namespace Practic.Controllers
{
    public class AimMakerController: Controller
    {
        private readonly IAllAims _aimRepository;
        private readonly AimMaker _aimMaker;
        private readonly AppDBContent _appDBContent;

        public AimMakerController(IAllAims aimRepository, AimMaker aimMaker, AppDBContent appDBContent)
        {
            _aimRepository = aimRepository;
            _aimMaker = aimMaker;
            _appDBContent = appDBContent;
        }
        public ViewResult Index()
        {
            var items = _aimMaker.getAimItems();
            _aimMaker.ListAimItems = items;
            var obj = new AimMakerViewModel
            {
                _AimMaker = _aimMaker
            };
            foreach(var element in _aimMaker.ListAimItems)
            {
                element.aim.Avaliable = false;
                _appDBContent.SaveChanges();
            }
            return View(obj);
        }

        public RedirectToActionResult StartAim(int id)
        {
            var item = _aimRepository.Aims.FirstOrDefault(index => index.Id == id);
            if(item != null)
            {
                _aimMaker.StartAim(item);
            }
            return RedirectToAction("Index");
        }
    }
}
