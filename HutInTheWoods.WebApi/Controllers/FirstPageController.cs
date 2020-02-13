using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HutInTheWoods.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstPageController : ControllerBase
    {
        [HttpGet]
        [Route("huts")]
        public IEnumerable<Hut> Get()
        {
            var repo = new DataRepository();
            return repo.GetHutsForFirstPage();
        }

        [HttpGet]
        [Route("news")]
        public IEnumerable<News> GetNews()
        {
            var repo = new DataRepository();
            return repo.GetLatestNews(3);
        }
    }
}