using Microsoft.EntityFrameworkCore;
using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UsersPlayerModel> UsersPlayers { get; set; }
        public DbSet<UsersPlayerPointsModel> UsersPlayersPoints { get; set; }
        public DbSet<UsersPlayerStateModel> UsersPlayerStates { get; set; }
        public DbSet<UsersItemModel> UsersItems { get; set; }
        public DbSet<UsersSponsorModel> UsersSponsors { get; set; }
        public DbSet<PlayerModel> Players  { get; set; }
        public DbSet<AuctionModel> Auctions { get; set; }
        public DbSet<SponsorsModel> Sponsors { get; set; }
        public DbSet<StadiumModel> Stadiums { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserDetailsModel> UsersDetails { get; set; }
        public DbSet<UsersMatchHistoryModel> UsersMatchesHistory { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<ExpensesModel> Expenses { get; set; }
        public DbSet<RankRequirementModel> RankRequirements { get; set; }
        public DbSet<BackgroundTaskModel> BackgroundTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=DESKTOP-JMD29TI\\SQLEXPRESS;Database=Basketball_Manager;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>()
                .Property(d => d.BirthDate)
                .HasColumnType("date");
            builder.Entity<UsersMatchHistoryModel>()
                .Property(d => d.MatchDate)
                .HasColumnType("date");
            builder.Entity<NotificationModel>()
                .Property(d => d.CreateDate)
                .HasColumnType("date");
            builder.Entity<ExpensesModel>()
                .Property(d => d.TransactionDate)
                .HasColumnType("date");

            builder.Entity<UsersPlayerModel>().HasOne(x => x.User)
                    .WithMany(x => x.UsersPlayers).HasForeignKey(x => x.UserId);
            builder.Entity<UsersItemModel>().HasOne(x => x.User)
                    .WithMany(x => x.UsersItems).HasForeignKey(x => x.UserId);
            builder.Entity<UsersMatchHistoryModel>().HasOne(x => x.User)
                    .WithMany(x => x.UserMatchesHistory).HasForeignKey(x => x.UserId);
            builder.Entity<UsersPlayerModel>().HasOne(x => x.Player)
                    .WithMany(x => x.UsersPlayers).HasForeignKey(x => x.PlayerId);
            builder.Entity<UsersItemModel>().HasOne(x => x.Item)
                    .WithMany(x => x.UsersItems).HasForeignKey(x => x.ItemId);
            builder.Entity<NotificationModel>().HasOne(x => x.User)
                    .WithMany(x => x.Notifications).HasForeignKey(x => x.UserId);
            builder.Entity<ExpensesModel>().HasOne(x => x.User)
                    .WithMany(x => x.Expenses).HasForeignKey(x => x.UserId);
            builder.Entity<UsersSponsorModel>().HasOne(x => x.Sponsor)
                    .WithMany(x => x.UserSponsors).HasForeignKey(x => x.SponsorId);

            builder.Entity<UserModel>().HasOne(x => x.UserDetail)
                    .WithOne(x=> x.User).HasForeignKey<UserDetailsModel>(x => x.UserId);
            builder.Entity<UserModel>().HasOne(x => x.Stadium)
                    .WithOne(x => x.User).HasForeignKey<StadiumModel>(x => x.UserId);
            builder.Entity<UserModel>().HasOne(x => x.UserSponsor)
                    .WithOne(x => x.User).HasForeignKey<UsersSponsorModel>(x => x.UserId);
            builder.Entity<UsersPlayerModel>().HasOne(x => x.Auction)
                    .WithOne(x => x.UsersPlayer).HasForeignKey<AuctionModel>(x => x.UserPlayerId);
            builder.Entity<UsersPlayerModel>().HasOne(x => x.UsersPlayerPoints)
                    .WithOne(x => x.UsersPlayer).HasForeignKey<UsersPlayerPointsModel>(x => x.UserPlayerId);
            builder.Entity<UsersPlayerModel>().HasOne(x => x.UsersPlayerState)
                   .WithOne(x => x.UsersPlayer).HasForeignKey<UsersPlayerStateModel>(x => x.UserPlayerId);

            //Enum to string
            builder
                .Entity<PlayerModel>()
                .Property(e => e.Rarity)
                .HasConversion(
                    v => v.ToString(),
                    v => (PlayerRarity)Enum.Parse(typeof(PlayerRarity), v));

            builder
                .Entity<UsersPlayerModel>()
                .Property(e => e.TrainingType)
                .HasConversion(
                    v => v.ToString(),
                    v => (Training)Enum.Parse(typeof(Training), v));
        }
    }
}
