// <auto-generated />
using System;
using Basketball_Manager_Db.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Basketball_Manager_Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211130184241_AuctionsRealtionsReversed")]
    partial class AuctionsRealtionsReversed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bid")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersPlayerId");

                    b.ToTable("AuctionDetails");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuctionDetailsId")
                        .HasColumnType("int");

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

                    b.HasIndex("AuctionDetailsId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ItemModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerInfoModel", b =>
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

                    b.ToTable("PlayersInfo");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.SportsHallModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersItemModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersMatchDetailsModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersMatchHistoryModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
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

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionDetailsModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UsersPlayerModel", "UsersPlayer")
                        .WithMany("AuctionDetails")
                        .HasForeignKey("UsersPlayerId");

                    b.Navigation("UsersPlayer");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.AuctionDetailsModel", "AuctionDetails")
                        .WithMany("Auctions")
                        .HasForeignKey("AuctionDetailsId");

                    b.Navigation("AuctionDetails");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.PlayerInfoModel", "PlayerInfo")
                        .WithMany("Players")
                        .HasForeignKey("PlayerInfoId");

                    b.Navigation("PlayerInfo");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.SponsorModel", "Sponsor")
                        .WithMany("UserModels")
                        .HasForeignKey("SponsorId");

                    b.HasOne("Basketball_Manager_Db.Models.SportsHallModel", "StadiumModel")
                        .WithMany("UserModels")
                        .HasForeignKey("SportsHallId");

                    b.Navigation("Sponsor");

                    b.Navigation("StadiumModel");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersItemModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.ItemModel", "Item")
                        .WithMany("UsersItems")
                        .HasForeignKey("ItemId");

                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UsersItems")
                        .HasForeignKey("UserId");

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersMatchDetailsModel", b =>
                {
                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UserMatchesDetails")
                        .HasForeignKey("UserId");

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
                        .HasForeignKey("PlayerId");

                    b.HasOne("Basketball_Manager_Db.Models.UserModel", "User")
                        .WithMany("UsersPlayers")
                        .HasForeignKey("UserId");

                    b.Navigation("Player");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.AuctionDetailsModel", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.ItemModel", b =>
                {
                    b.Navigation("UsersItems");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerInfoModel", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.PlayerModel", b =>
                {
                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SponsorModel", b =>
                {
                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.SportsHallModel", b =>
                {
                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UserModel", b =>
                {
                    b.Navigation("UserMatchesDetails");

                    b.Navigation("UserMatchesHistory");

                    b.Navigation("UsersItems");

                    b.Navigation("UsersPlayers");
                });

            modelBuilder.Entity("Basketball_Manager_Db.Models.UsersPlayerModel", b =>
                {
                    b.Navigation("AuctionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
