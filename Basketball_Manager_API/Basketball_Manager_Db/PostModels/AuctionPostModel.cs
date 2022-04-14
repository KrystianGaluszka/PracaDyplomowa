using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.PostModels
{
    public class AuctionPostModel
    {
        public string UserId { get; set; }
        public int UserPlayerId { get; set; }
        public double Price { get; set; }
        public double Bid { get; set; }
        
    }
}
