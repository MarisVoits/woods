using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;

namespace HutInTheWoods.Mvc.Models
{
    public class HutsIndexViewModel
    {
        public IEnumerable<Hut> Huts { get; set; }
    }
}
