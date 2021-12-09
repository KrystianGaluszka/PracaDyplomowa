using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.PostModels
{
    public class AuctionPostModel
    {
        public int UserPlayerId { get; set; }
        public string UserId { get; set; }
        public float Price { get; set; }
        public float Bid { get; set; }
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
    }
}
