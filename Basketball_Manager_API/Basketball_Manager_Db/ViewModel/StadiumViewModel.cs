using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class StadiumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float IncomePerViewer { get; set; }
        public int SeatsCapacity { get; set; }
    }
}
