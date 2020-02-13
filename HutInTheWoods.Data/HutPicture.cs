using System;
using System.Collections.Generic;
using System.Text;

namespace HutInTheWoods.Data
{
    public class HutPicture
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int HutId { get; set; }
    }
}
