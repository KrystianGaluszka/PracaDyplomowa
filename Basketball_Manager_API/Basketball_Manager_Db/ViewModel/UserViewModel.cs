using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public StadiumViewModel Stadium { get; set; }
        public UsersSponsorViewModel UserSponsor { get; set; }
        public UserDetailViewModel UserDetail { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Email { get; set; }
        public string ClubName { get; set; }
        public string Country { get; set; }
        public DateTime? BirthDate { get; set; }
        public double Money { get; set; }
        public string ProfilePicturePath { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsInQueue { get; set; }
        public bool IsAccepted { get; set; }
        public IEnumerable<UsersPlayerViewModel> UsersPlayers { get; set; }
        public IEnumerable<UserItemViewModel> UsersItems { get; set; }
        public IEnumerable<UsersMatchHistoryViewModel> UserMatchesHistory { get; set; }
        public IEnumerable<NotificationViewModel> Notifications { get; set; }
        public IEnumerable<ExpensesViewModel> Expenses { get; set; }
    }
}
