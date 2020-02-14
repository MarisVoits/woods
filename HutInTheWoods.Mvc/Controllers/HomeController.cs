using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HutInTheWoods.Mvc.Models;

namespace HutInTheWoods.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            var rep = new DataRepository();

            model.News = rep.GetLatestNews(3);
            model.Huts = rep.GetHutsForFirstPage();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
