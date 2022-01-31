using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemModel, ItemViewModel>();
            CreateMap<ItemPutModel, UsersItemModel>();
            AllowNullCollections = true;
        }
    }
}
