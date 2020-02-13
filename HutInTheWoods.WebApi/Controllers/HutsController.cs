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
    public class HutsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Hut> GetHuts()
        {
            var repo = new DataRepository();
            return repo.GetHuts();
        }

        [HttpGet]
        [Route("{id}")]
        public Hut GetHutById(int id)
        {
            var repo = new DataRepository();
            return repo.GetHutById(id);
        }

        [HttpGet]
        [Route("{id}/pictures")]
        public IEnumerable<HutPicture> GetPicturesForHut(int id)
        {
            var repo = new DataRepository();
            return repo.GetHutPicturesById(id);
        }
    }
}