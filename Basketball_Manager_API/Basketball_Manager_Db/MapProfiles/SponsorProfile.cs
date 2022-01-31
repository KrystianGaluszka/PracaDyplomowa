using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class SponsorProfile : Profile
    {
        public SponsorProfile()
        {
            CreateMap<SponsorModel, SponsorViewModel>();
                    //.ForPath(dest => dest.UserIds, opts => opts.MapFrom(src => src.Users.Select(x => x.Id)));
            AllowNullCollections = true;
        }
    }
}
