using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UsersPlayerViewModel UsersPlayer { get; set; }
        public double Price { get; set; }
        public double Bid { get; set; }
        public string BidUserId { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
