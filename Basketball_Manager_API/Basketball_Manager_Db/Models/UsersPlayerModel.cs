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
        public int PlayerId { get; set; }
        public virtual PlayerModel Player { get; set; }
        public virtual AuctionModel Auction { get; set; }
        public virtual UsersPlayerPointsModel UsersPlayerPoints { get; set; }
        public virtual UsersPlayerStateModel UsersPlayerState { get; set; }
        public string Club { get; set; }
        public string League { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int RequiredExperience { get; set; }
        public double Condition { get; set; }
        public double Salary { get; set; }
        public int Contract { get; set; }
        public int Score { get; set; }
        public Training TrainingType { get; set; }
    }

    public enum Training
    {
        Rest,
        Light,
        Medium,
        Hard,
        None
    }
}