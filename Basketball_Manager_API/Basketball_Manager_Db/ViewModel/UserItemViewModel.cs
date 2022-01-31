using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.ViewModel
{
    public class UserItemViewModel
    {
        public int Id { get; set; }
        public ItemViewModel Item { get; set; }
        public int Count { get; set; }
    }
}
