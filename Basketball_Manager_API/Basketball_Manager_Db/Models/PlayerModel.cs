using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }
        public virtual PlayerInfoModel PlayerInfo { get; set; }
        public int Level { get; set; }
        public float Salary { get; set; }
        public virtual IEnumerable<UsersPlayerModel> UsersPlayers { get; set; }
    }
}