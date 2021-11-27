using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class SportsHallModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float IncomePerViewer { get; set; }
        public int SeatsCapacity { get; set; }
        public IEnumerable<UserModel> UserModels { get; set; }
    }
}