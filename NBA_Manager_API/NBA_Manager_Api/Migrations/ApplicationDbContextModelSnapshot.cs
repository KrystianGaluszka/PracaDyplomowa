﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBA_Manager_Api.DataAccess;

namespace NBA_Manager_Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NBA_Manager_Api.Models.AuctionDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<float>("Bid")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UsersPlayerId");

                    b.ToTable("AuctionDetails");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.AuctionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Club")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Condition")
                        .HasColumnType("real");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("League")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.PlayerInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Club")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<bool>("IsLegend")
                        .HasColumnType("bit");

                    b.Property<string>("League")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("PlayerInfos");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerInfoId")
                        .HasColumnType("int");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PlayerInfoId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.SponsorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("MatchPrize")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TitlePrize")
                        .HasColumnType("real");

                    b.Property<float>("WinPrize")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.SportsHallModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("IncomePerViewer")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SeatsCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SportsHalls");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserMatchDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasIndex("UserId");

                    b.ToTable("UsersMatchDetails");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserMatchHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OpponentClub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpponentScore")
                        .HasColumnType("int");

                    b.Property<string>("UserClub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersMatchHistory");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Money")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.Property<int?>("SportsHallId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("SportsHallId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UsersItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersItems");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UsersPlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Condition")
                        .HasColumnType("real");

                    b.Property<int>("Contract")
                        .HasColumnType("int");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnAuction")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersPlayers");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.AuctionDetailsModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.AuctionModel", "Auction")
                        .WithMany("AuctionDetails")
                        .HasForeignKey("AuctionId");

                    b.HasOne("NBA_Manager_Api.Models.UsersPlayerModel", "UsersPlayer")
                        .WithMany("AuctionDetails")
                        .HasForeignKey("UsersPlayerId");

                    b.Navigation("Auction");

                    b.Navigation("UsersPlayer");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.PlayerModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.PlayerInfoModel", "PlayerInfo")
                        .WithMany("Players")
                        .HasForeignKey("PlayerInfoId");

                    b.Navigation("PlayerInfo");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserMatchDetailsModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.UserModel", "User")
                        .WithMany("UserMatchesDetails")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserMatchHistoryModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.UserModel", "User")
                        .WithMany("UserMatchesHistory")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.SponsorModel", "Sponsor")
                        .WithMany("UserModels")
                        .HasForeignKey("SponsorId");

                    b.HasOne("NBA_Manager_Api.Models.SportsHallModel", "SportsHall")
                        .WithMany("UserModels")
                        .HasForeignKey("SportsHallId");

                    b.Navigation("Sponsor");

                    b.Navigation("SportsHall");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UsersItemModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.ItemModel", "Item")
                        .WithMany("UsersItems")
                        .HasForeignKey("ItemId");

                    b.HasOne("NBA_Manager_Api.Models.UserModel", "User")
                        .WithMany("UsersItems")
                        .HasForeignKey("UserId");

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UsersPlayerModel", b =>
                {
                    b.HasOne("NBA_Manager_Api.Models.PlayerModel", "Player")
                        .WithMany("UsersPlayers")
                        .HasForeignKey("PlayerId");

                    b.HasOne("NBA_Manager_Api.Models.UserModel", "User")
                        .WithMany("UsersPlayers")
                        .HasForeignKey("UserId");

                    b.Navigation("Player");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.AuctionModel", b =>
                {
                    b.Navigation("AuctionDetails");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.ItemModel", b =>
                {
                    b.Navigation("UsersItems");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.PlayerInfoModel", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.PlayerModel", b =>
                {
                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.SponsorModel", b =>
                {
                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.SportsHallModel", b =>
                {
                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UserModel", b =>
                {
                    b.Navigation("UserMatchesDetails");

                    b.Navigation("UserMatchesHistory");

                    b.Navigation("UsersItems");

                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("NBA_Manager_Api.Models.UsersPlayerModel", b =>
                {
                    b.Navigation("AuctionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
