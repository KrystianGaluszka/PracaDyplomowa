using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UsersMatchHisotryViewModel
    {
        public int Id { get; set; }
        public string UserClub { get; set; }
        public string OpponentClub { get; set; }
        public int UserScore { get; set; }
        public int OpponentScore { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
