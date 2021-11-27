using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class AuctionModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Club { get; set; }
        public string League { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public int Level { get; set; }
        public float Condition { get; set; }
        public float Salary { get; set; }
        public virtual IEnumerable<AuctionDetailsModel> AuctionDetails { get; set; }
    }
}