using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class UsersSponsorModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int? SponsorId { get; set; }
        public virtual SponsorsModel Sponsor { get; set; }
        public int MatchPrizeCount { get; set; }
        public double MatchPrizeTotality { get; set; }
        public int WinPrizeCount { get; set; }
        public double WinPrizeTotality { get; set; }
        public int TitlePrizeCount { get; set; }
        public double TitlePrizeTotality { get; set; }
    }
}