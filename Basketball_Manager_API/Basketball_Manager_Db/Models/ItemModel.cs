using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public virtual IEnumerable<UsersItemModel> UsersItems { get; set; }
    }
}
