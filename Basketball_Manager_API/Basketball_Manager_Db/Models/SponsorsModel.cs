using System.Collections.Generic;

namespace Basketball_Manager_Db.Models
{
    public class SponsorsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MatchPrize { get; set; }
        public double WinPrize { get; set; }
        public double TitlePrize { get; set; }
        public int RequiredLevel { get; set; }
        public virtual IEnumerable<UsersSponsorModel> UserSponsors{ get; set; }
    }
}
