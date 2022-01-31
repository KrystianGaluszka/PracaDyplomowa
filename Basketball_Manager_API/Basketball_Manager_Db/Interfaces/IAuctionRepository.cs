using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<AuctionViewModel>> GetAllAuctions();
        Task<AuctionViewModel> GetAuction(int id);
        Task<AuctionModel> PostAuction(AuctionPostModel auctionPostModel);
    }
}
