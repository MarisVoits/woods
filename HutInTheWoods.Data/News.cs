using System;
using System.Collections.Generic;
using System.Text;

namespace HutInTheWoods.Data
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public DateTime Date { get; set; }

    }
}
