using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Models
{
    public class UsersMatchDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int RankPoints { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
    }
}
