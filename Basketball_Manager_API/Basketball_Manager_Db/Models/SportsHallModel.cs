using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class SportsHallModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float IncomePerViewer { get; set; }
        public int SeatsCapacity { get; set; }
        public virtual IEnumerable<UserModel> UserModels { get; set; }
    }
}