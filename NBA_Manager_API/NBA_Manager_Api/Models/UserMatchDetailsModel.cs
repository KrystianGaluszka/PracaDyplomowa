using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Manager_Api.Models
{
    public class UserMatchDetailsModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public int RankPoints { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
    }
}
