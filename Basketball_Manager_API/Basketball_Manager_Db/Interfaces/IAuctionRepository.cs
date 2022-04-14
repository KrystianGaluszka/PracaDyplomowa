using Basketball_Manager_Db.DeleteModels;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
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
        Task<string> PostAuction(AuctionPostModel auctionPostModel);
        Task<string> BidPlayer(BidFromAuctionPutModel bidFromAuction);
        Task<string> BidEnd(BidFromAuctionPutModel bidFromAuction);
        Task<string> BuyPlayer(BuyFromAuctionPutModel buyFromAuction);
        Task<string> DeleteAfterPurchase(int auctionId);
        Task<string> QuickSell(QuickSellDeleteModel quickSellDeleteModel);
        Task<string> RemovePlayer(RemoveFromAuctionDeleteModel removeFromAuction);
    }
}
