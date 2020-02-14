using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;

namespace HutInTheWoods.Mvc.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Hut> Huts { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
