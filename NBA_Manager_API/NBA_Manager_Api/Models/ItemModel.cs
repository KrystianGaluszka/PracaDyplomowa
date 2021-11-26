using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Manager_Api.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UsersItemModel> UsersItems { get; set; }
    }
}
