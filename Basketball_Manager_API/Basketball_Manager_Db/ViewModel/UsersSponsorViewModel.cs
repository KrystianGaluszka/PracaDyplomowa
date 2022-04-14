using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UsersSponsorViewModel
    {
        public int Id { get; set; }
        public SponsorsViewModel Sponsor { get; set; }
        public int MatchPrizeCount { get; set; }
        public double MatchPrizeTotality { get; set; }
        public int WinPrizeCount { get; set; }
        public double WinPrizeTotality { get; set; }
        public int TitlePrizeCount { get; set; }
        public double TitlePrizeTotality { get; set; }
    }
}
