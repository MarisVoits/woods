using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HutInTheWoods.Data;

namespace HutInTheWoods.Mvc.Models
{
    public class HutDetailsViewModel
    {
        public Hut Hut { get; set; }
        public IEnumerable<HutPicture> Pictures { get; set; }
    }
}
