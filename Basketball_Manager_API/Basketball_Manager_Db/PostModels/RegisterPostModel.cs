using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.PostModels
{
    public class RegisterPostModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
