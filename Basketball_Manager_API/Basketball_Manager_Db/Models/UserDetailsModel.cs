using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Models
{
    public class UserDetailsModel
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
        public string LastSeasonRank { get; set; }
        public int AllMatchesPlayed { get; set; }
        public int AllMatchesWon { get; set; }
        public int AllMatchesDrawn { get; set; }
        public int AllMatchesLost { get; set; }
    }
}
