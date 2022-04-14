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
        public string UserId { get; set; }
        public int UserPlayerId { get; set; }
        public virtual UsersPlayerModel UsersPlayer { get; set; }
        public double Price { get; set; }
        public double Bid { get; set; }
        public string BidUserId { get; set; }
    }
}