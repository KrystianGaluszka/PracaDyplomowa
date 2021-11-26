using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class SponsorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MatchPrize { get; set; }
        public float WinPrize { get; set; }
        public float TitlePrize { get; set; }
        public IEnumerable<UserModel> UserModels { get; set; }
    }
}