﻿// <auto-generated />
using System;
using Basketball_Manager_Db.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220419165014_newPropAuctionAndExchangepropsUserPlayers")]
    partial class newPropAuctionAndExchangepropsUserPlayers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Bid")
                        .HasColumnType("float");

                    b.Property<string>("BidUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserPlayerId")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.BackgroundTaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsStarted")
                        .HasColumnType("bit");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User2Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BackgroundTasks");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ExpensesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.NotificationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.RankRequirementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointsLimit")
                        .HasColumnType("int");

                    b.Property<int>("PointsRequired")
                        .HasColumnType("int");

                    b.Property<string>("RankName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RankRequirements");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("MatchPrize")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredLevel")
                        .HasColumnType("int");

                    b.Property<double>("TitlePrize")
                        .HasColumnType("float");

                    b.Property<double>("WinPrize")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.StadiumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("IncomePerViewer")
                        .HasColumnType("float");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SeatsCapacity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AllMatchesDrawn")
                        .HasColumnType("int");

                    b.Property<int>("AllMatchesLost")
                        .HasColumnType("int");

                    b.Property<int>("AllMatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("AllMatchesWon")
                        .HasColumnType("int");

                    b.Property<string>("LastSeasonRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatchesDrawn")
                        .HasColumnType("int");

                    b.Property<int>("MatchesLost")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("MatchesWon")
                        .HasColumnType("int");

                    b.Property<int>("RankPoints")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("ClubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInQueue")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlaying")
                        .HasColumnType("bit");

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersItems");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersMatchHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MatchDate")
                        .HasColumnType("date");

                    b.Property<int>("MinutesLeft")
                        .HasColumnType("int");

                    b.Property<string>("Mvp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MvpScore")
                        .HasColumnType("int");

                    b.Property<int>("SecondsLeft")
                        .HasColumnType("int");

                    b.Property<string>("User2Club")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User2Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User2Score")
                        .HasColumnType("int");

                    b.Property<string>("UserClub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersMatchesHistory");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Club")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Condition")
                        .HasColumnType("float");

                    b.Property<int>("Contract")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("League")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("RequiredExperience")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerPointsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AllOnePoints")
                        .HasColumnType("int");

                    b.Property<int>("AllThreePoints")
                        .HasColumnType("int");

                    b.Property<int>("AllTwoPoints")
                        .HasColumnType("int");

                    b.Property<int>("OnePoints")
                        .HasColumnType("int");

                    b.Property<int>("ThreePoints")
                        .HasColumnType("int");

                    b.Property<int>("TwoPoints")
                        .HasColumnType("int");

                    b.Property<int>("UserPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserPlayerId")
                        .IsUnique();

                    b.ToTable("UsersPlayersPoints");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerStateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsBoosted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInjured")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnAuction")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnBench")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlaying")
                        .HasColumnType("bit");

                    b.Property<int>("UserPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserPlayerId")
                        .IsUnique();

                    b.ToTable("UsersPlayerStates");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersSponsorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MatchPrizeCount")
                        .HasColumnType("int");

                    b.Property<double>("MatchPrizeTotality")
                        .HasColumnType("float");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.Property<int>("TitlePrizeCount")
                        .HasColumnType("int");

                    b.Property<double>("TitlePrizeTotality")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WinPrizeCount")
                        .HasColumnType("int");

                    b.Property<double>("WinPrizeTotality")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UsersSponsors");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UsersPlayerModel", "UsersPlayer")
                        .WithOne("Auction")
                        .HasForeignKey("Basketball_Manager_Db.Models.AuctionModel", "UserPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersPlayer");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ExpensesModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.NotificationModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.StadiumModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithOne("Stadium")
                        .HasForeignKey("Basketball_Manager_Db.Models.StadiumModel", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserDetailsModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Basketball_Manager_Db.Models.UserDetailsModel", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersItemModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.ItemModel", "Item")
                        .WithMany("UsersItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UsersItems")
                        .HasForeignKey("UserId");

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersMatchHistoryModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UserMatchesHistory")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.PlayerModel", "Player")
                        .WithMany("UsersPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UsersPlayers")
                        .HasForeignKey("UserId");

                    b.Navigation("Player");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerPointsModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UsersPlayerModel", "UsersPlayer")
                        .WithOne("UsersPlayerPoints")
                        .HasForeignKey("Basketball_Manager_Db.Models.UsersPlayerPointsModel", "UserPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersPlayer");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerStateModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UsersPlayerModel", "UsersPlayer")
                        .WithOne("UsersPlayerState")
                        .HasForeignKey("Basketball_Manager_Db.Models.UsersPlayerStateModel", "UserPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersPlayer");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersSponsorModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.SponsorsModel", "Sponsor")
                        .WithMany("UserSponsors")
                        .HasForeignKey("SponsorId");

                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithOne("UserSponsor")
                        .HasForeignKey("Basketball_Manager_Db.Models.UsersSponsorModel", "UserId");

                    b.Navigation("Sponsor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ItemModel", b =>
                {
                    b.Navigation("UsersItems");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
                {
                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorsModel", b =>
                {
                    b.Navigation("UserSponsors");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Notifications");

                    b.Navigation("Stadium");

                    b.Navigation("UserDetail");

                    b.Navigation("UserMatchesHistory");

                    b.Navigation("UserSponsor");

                    b.Navigation("UsersItems");

                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.Navigation("Auction");

                    b.Navigation("UsersPlayerPoints");

                    b.Navigation("UsersPlayerState");
                });
#pragma warning restore 612, 618
        }
    }
}
