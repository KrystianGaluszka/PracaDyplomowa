using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Models
{
    public class UsersMatchHistoryModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public string UserClub { get; set; }
        public string OpponentClub { get; set; }
        public int UserScore { get; set; }
        public int OpponentScore { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
