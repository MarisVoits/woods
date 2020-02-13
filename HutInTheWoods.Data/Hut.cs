using System;
using System.Collections.Generic;
using System.Text;

namespace HutInTheWoods.Data
{
    public class Hut
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string BigPicturePath { get; set; }
    }
}
