using Microsoft.EntityFrameworkCore;
using NBA_Manager_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Manager_Api.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UsersPlayerModel> UsersPlayers { get; set; }
        public DbSet<UsersItemModel> UsersItems { get; set; }
        public DbSet<PlayerModel> Players  { get; set; }
        public DbSet<PlayerInfoModel> PlayerInfos { get; set; }
        public DbSet<AuctionModel> Auctions { get; set; }
        public DbSet<AuctionDetailsModel> AuctionDetails { get; set; }
        public DbSet<SponsorModel> Sponsors { get; set; }
        public DbSet<SportsHallModel> SportsHalls { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserMatchDetailsModel> UsersMatchDetails { get; set; }
        public DbSet<UserMatchHistoryModel> UsersMatchHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UsersPlayerModel>().HasOne(x => x.User)
                    .WithMany(x => x.UsersPlayers).HasForeignKey(x => x.UserId);
            builder.Entity<UsersItemModel>().HasOne(x => x.User)
                    .WithMany(x => x.UsersItems).HasForeignKey(x => x.UserId);
            builder.Entity<UserMatchHistoryModel>().HasOne(x => x.User)
                    .WithMany(x => x.UserMatchesHistory).HasForeignKey(x => x.UserId);
            builder.Entity<UserMatchDetailsModel>().HasOne(x => x.User)
                    .WithMany(x => x.UserMatchesDetails).HasForeignKey(x => x.UserId);
        }
    }
}
