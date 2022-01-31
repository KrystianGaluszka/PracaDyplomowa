using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionModel, AuctionViewModel>();
            CreateMap<AuctionPostModel, AuctionModel>();
            AllowNullCollections = true;
        }
    }
}
