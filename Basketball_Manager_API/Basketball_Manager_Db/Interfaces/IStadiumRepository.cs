﻿using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IStadiumRepository
    {
        Task<IEnumerable<StadiumModel>> GetAllStadiums();
        Task<StadiumModel> GetStadium(int id);
    }
}