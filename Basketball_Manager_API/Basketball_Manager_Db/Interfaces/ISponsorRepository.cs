﻿using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface ISponsorRepository
    {
        Task<IEnumerable<SponsorViewModel>> GetAllSponsors();
        Task<SponsorViewModel> GetSponsor(int id);
    }
}
