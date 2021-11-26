using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class AuctionModel
    {
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
        public IEnumerable<AuctionDetailsModel> AuctionDetails { get; set; }
    }
}