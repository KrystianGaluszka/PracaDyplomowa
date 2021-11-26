﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Manager_Api.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public virtual PlayerInfoModel PlayerInfo { get; set; }
        public int Level { get; set; }
        public float Salary { get; set; }
        public IEnumerable<UsersPlayerModel> UsersPlayers { get; set; }
    }
}