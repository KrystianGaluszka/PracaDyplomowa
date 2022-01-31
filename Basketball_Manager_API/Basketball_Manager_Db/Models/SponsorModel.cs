using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class SponsorModel
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public float MatchPrize { get; set; }
        public float WinPrize { get; set; }
        public float TitlePrize { get; set; }
        public virtual IEnumerable<UserModel> Users { get; set; }
    }
}