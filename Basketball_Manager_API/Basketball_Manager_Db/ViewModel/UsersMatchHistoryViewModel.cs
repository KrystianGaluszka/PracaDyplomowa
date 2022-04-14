using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UsersMatchHistoryViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string User2Id { get; set; }
        public string UserClub { get; set; }
        public string User2Club { get; set; }
        public int UserScore { get; set; }
        public int User2Score { get; set; }
        public string Mvp { get; set; }
        public int MvpScore { get; set; }
        public int MinutesLeft { get; set; }
        public int SecondsLeft { get; set; }
        public bool IsDone { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
