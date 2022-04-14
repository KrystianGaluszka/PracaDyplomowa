using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }
        public int RankPoints { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
        public string LastSeasonRank { get; set; }
        public int AllMatchesPlayed { get; set; }
        public int AllMatchesWon { get; set; }
        public int AllMatchesDrawn { get; set; }
        public int AllMatchesLost { get; set; }
    }
}
