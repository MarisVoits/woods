
using System.Collections.Generic;
using HutInTheWoods.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HutInTheWoods.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<News> GetNewsList()
        {
            var repo = new DataRepository();
            return repo.GetNews();
        }

        [HttpGet]
        [Route("{id}")]
        public News GetNewsById(int id)
        {
            var repo = new DataRepository();
            return repo.GetNewsById(id);
        }
    }
}