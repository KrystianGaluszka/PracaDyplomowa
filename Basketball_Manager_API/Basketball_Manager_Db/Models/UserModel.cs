using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }
        public virtual SportsHallModel SportsHall { get; set; }
        public virtual SponsorModel Sponsor { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ClubName { get; set; }
        public string Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public float Money { get; set; }
        public string ProfilePicturePath { get; set; }
        public virtual IEnumerable<UsersPlayerModel> UsersPlayers { get; set; }
        public virtual IEnumerable<UsersItemModel> UsersItems { get; set; }
        public virtual IEnumerable<UsersMatchDetailsModel> UserMatchesDetails { get; set; }
        public virtual IEnumerable<UsersMatchHistoryModel> UserMatchesHistory { get; set; }
    }
}