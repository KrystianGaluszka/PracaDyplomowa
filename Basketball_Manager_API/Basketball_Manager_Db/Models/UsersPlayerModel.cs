using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class UsersPlayerModel
    {
        [Key]
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
        public virtual IEnumerable<AuctionDetailsModel> AuctionDetails { get; set; }
    }
}