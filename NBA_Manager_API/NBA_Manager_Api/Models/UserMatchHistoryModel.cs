using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Manager_Api.Models
{
    public class UserMatchHistoryModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public string UserClub { get; set; }
        public string OpponentClub { get; set; }
        public int UserScore { get; set; }
        public int OpponentScore { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
