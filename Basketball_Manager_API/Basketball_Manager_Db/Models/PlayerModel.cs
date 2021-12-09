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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Club { get; set; }
        public string League { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public bool IsLegend { get; set; }
        public int Level { get; set; }
        public float Salary { get; set; }
        public virtual IEnumerable<UsersPlayerModel> UsersPlayers { get; set; }
    }
}