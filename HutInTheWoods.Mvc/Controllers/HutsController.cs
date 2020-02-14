using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;
using HutInTheWoods.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HutInTheWoods.Mvc.Controllers
{
    [Route("Huts")]
    public class HutsController : Controller
    {
        public IActionResult Index()
        {
            var model = new HutsIndexViewModel();
            var repo = new DataRepository();

            model.Huts = repo.GetHuts();


            return View(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var model = new HutDetailsViewModel();
            var repo = new DataRepository();

            model.Hut = repo.GetHutById(id);
            model.Pictures = repo.GetHutPicturesById(id);

            return View(model);
        }
    }
}