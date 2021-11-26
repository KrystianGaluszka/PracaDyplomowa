using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class UsersPlayerModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual PlayerModel Player { get; set; }
        public int Level { get; set; }
        public float Condition { get; set; }
        public float Salary { get; set; }
        public int Contract { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsOnAuction { get; set; }
        public IEnumerable<AuctionDetailsModel> AuctionDetails { get; set; }
    }
}