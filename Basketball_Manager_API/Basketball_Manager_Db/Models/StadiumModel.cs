using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class StadiumModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double IncomePerViewer { get; set; }
        public int SeatsCapacity { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}