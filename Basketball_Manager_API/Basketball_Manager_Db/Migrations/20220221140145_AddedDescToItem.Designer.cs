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
    [Migration("20220221140145_AddedDescToItem")]
    partial class AddedDescToItem
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

                    b.Property<float>("Bid")
                        .HasColumnType("real");

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

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPlayerId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserPlayerId")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ExpensesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

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

                    b.Property<float>("Price")
                        .HasColumnType("real");

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

                    b.Property<string>("Club")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Basketball_Manager_Db.Models.StadiumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("IncomePerViewer")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SeatsCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("StadiumId");

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

                    b.Property<DateTime?>("MatchDate")
                        .HasColumnType("date");

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

                    b.ToTable("UsersMatchesHistory");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Condition")
                        .HasColumnType("real");

                    b.Property<int>("Contract")
                        .HasColumnType("int");

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

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserDetailsModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Basketball_Manager_Db.Models.UserDetailsModel", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.SponsorModel", "Sponsor")
                        .WithMany("Users")
                        .HasForeignKey("SponsorId");

                    b.HasOne("Basketball_Manager_Db.Models.StadiumModel", "Stadium")
                        .WithMany("Users")
                        .HasForeignKey("StadiumId");

                    b.Navigation("Sponsor");

                    b.Navigation("Stadium");
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.ItemModel", b =>
                {
                    b.Navigation("UsersItems");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
                {
                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.StadiumModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Notifications");

                    b.Navigation("UserDetail");

                    b.Navigation("UserMatchesHistory");

                    b.Navigation("UsersItems");

                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.Navigation("Auction");
                });
#pragma warning restore 612, 618
        }
    }
}
