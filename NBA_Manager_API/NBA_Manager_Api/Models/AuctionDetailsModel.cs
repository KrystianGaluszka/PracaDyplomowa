using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class AuctionDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public virtual UsersPlayerModel UsersPlayer { get; set; }
        public string UserId { get; set; }
        public virtual AuctionModel Auction { get; set; }
        public float Price { get; set; }
        public float Bid { get; set; }
    }
}