﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class UsersItemModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User{ get; set; }
        public virtual ItemModel Item { get; set; }
        public int Count { get; set; }
    }
}