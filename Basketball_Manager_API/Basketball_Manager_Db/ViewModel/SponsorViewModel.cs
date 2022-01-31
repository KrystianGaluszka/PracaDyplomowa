using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class SponsorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MatchPrize { get; set; }
        public float WinPrize { get; set; }
        public float TitlePrize { get; set; }
    }
}
