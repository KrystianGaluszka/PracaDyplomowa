using Basketball_Manager_Db.Models;
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
        public UserViewModel User { get; set; }
        public UsersPlayerPointsViewModel UsersPlayerPoints { get; set; }
        public UsersPlayerStateViewModel UsersPlayerState { get; set; }
        public string Club { get; set; }
        public string League { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int RequiredExperience { get; set; }
        public double Condition { get; set; }
        public double Salary { get; set; }
        public int Contract { get; set; }
        public int Score { get; set; }
        public string TrainingType { get; set; }
    }
}
