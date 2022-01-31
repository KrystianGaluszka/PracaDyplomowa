using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class UserDetailsProfile : Profile
    {
        public UserDetailsProfile()
        {
            CreateMap<UserDetailsModel, UserDetailViewModel>();
            AllowNullCollections = true;
        }
    }
}
