using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UsersPlayerViewModel
    {
        public int Id { get; set; }
        public PlayerViewModel Player{ get; set; }
        public AuctionViewModel Auction { get; set; }
        public int Level { get; set; }
        public float Condition { get; set; }
        public float Salary { get; set; }
        public int Contract { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsOnAuction { get; set; }
    }
}
