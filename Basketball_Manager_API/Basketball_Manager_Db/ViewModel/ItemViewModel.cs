using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
