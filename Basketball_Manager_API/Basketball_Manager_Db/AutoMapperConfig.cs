using AutoMapper;
using Basketball_Manager_Db.MapProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuctionProfile>();
                cfg.AddProfile<ExpensesProfile>();
                cfg.AddProfile<ItemProfile>();
                cfg.AddProfile<PlayerProfile>();
                cfg.AddProfile<UserSponsorProfile>();
                cfg.AddProfile<StadiumProfile>();
                cfg.AddProfile<UserDetailsProfile>();
                cfg.AddProfile<UserItemsProfile>();
                cfg.AddProfile<UserMatchesHistoryProfile>();
                cfg.AddProfile<UserPlayerProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<NotificationProfile>();
                cfg.AddProfile<SponsorsProfile>();
                cfg.AddProfile<RankRequirementProfile>();
                cfg.AddProfile<BackgroundTaskProfile>();
            });

            return config;
        }
    }
}
