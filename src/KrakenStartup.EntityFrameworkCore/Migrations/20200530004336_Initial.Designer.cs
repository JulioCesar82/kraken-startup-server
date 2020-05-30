﻿// <auto-generated />
using System;
using KrakenStartup.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KrakenStartup.Migrations
{
    [DbContext(typeof(KrakenStartupDbContext))]
    [Migration("20200530004336_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KrakenStartup.AddressDocumentations.AddressDocumentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("NeighborhoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ADDRESSDOCUMENTATION");
                });

            modelBuilder.Entity("KrakenStartup.CarDocumentations.CarDocumentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CARDOCUMENTATION");
                });

            modelBuilder.Entity("KrakenStartup.CreditCards.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Credential")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CREDITCARD");
                });

            modelBuilder.Entity("KrakenStartup.DriverDocumentations.DriverDocumentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DRIVERDOCUMENTATION");
                });

            modelBuilder.Entity("KrakenStartup.Identifications.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IDENTIFICATION");
                });

            modelBuilder.Entity("KrakenStartup.ParkingSchedules.ParkingSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingId")
                        .HasColumnType("int");

                    b.Property<byte>("Repetition")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("PARKINGSCHEDULE");
                });

            modelBuilder.Entity("KrakenStartup.ParkingTransactions.ParkingTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<int>("RentParkingId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("TransactionInfo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserCreditCardId")
                        .HasColumnType("int");

                    b.Property<int?>("UserWalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentParkingId");

                    b.HasIndex("UserCreditCardId");

                    b.HasIndex("UserWalletId");

                    b.ToTable("PARKINGTRANSACTION");
                });

            modelBuilder.Entity("KrakenStartup.Parkings.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressDocumentId")
                        .HasColumnType("int");

                    b.Property<decimal>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressDocumentId");

                    b.HasIndex("WalletId");

                    b.ToTable("PARKING");
                });

            modelBuilder.Entity("KrakenStartup.RentParkings.RentParking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkingScheduleId")
                        .HasColumnType("int");

                    b.Property<byte>("PercentageTime")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserVoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingScheduleId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserVoucherId");

                    b.ToTable("RENTPARKING");
                });

            modelBuilder.Entity("KrakenStartup.UsersCreditCards.UserCreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditCardId")
                        .HasColumnType("int");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("UserId");

                    b.ToTable("USERCREDITCARD");
                });

            modelBuilder.Entity("KrakenStartup.UsersProfile.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressDocumentationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DriverDocumentationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("FingerPrint")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("IdentificationId")
                        .HasColumnType("int");

                    b.Property<byte>("Language")
                        .HasColumnType("tinyint");

                    b.Property<byte>("LastFailedLogin")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("MultiFactor")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte>("PhoneRegion")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserWalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressDocumentationId");

                    b.HasIndex("DriverDocumentationId")
                        .IsUnique()
                        .HasFilter("[DriverDocumentationId] IS NOT NULL");

                    b.HasIndex("IdentificationId")
                        .IsUnique()
                        .HasFilter("[IdentificationId] IS NOT NULL");

                    b.HasIndex("UserWalletId")
                        .IsUnique();

                    b.ToTable("USERPROFILE");
                });

            modelBuilder.Entity("KrakenStartup.UsersVouchers.UserVoucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VoucherId");

                    b.ToTable("USERVOUCHER");
                });

            modelBuilder.Entity("KrakenStartup.UsersWallets.UserWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("CurrencyType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("USERWALLET");
                });

            modelBuilder.Entity("KrakenStartup.Vouchers.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AmountMoney")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<int?>("MinimumPurchaseValue")
                        .HasColumnType("int");

                    b.Property<int?>("PercentageValue")
                        .HasColumnType("int");

                    b.Property<bool>("SingleUse")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VOUCHER");
                });

            modelBuilder.Entity("KrakenStartup.CarDocumentations.CarDocumentation", b =>
                {
                    b.HasOne("KrakenStartup.UsersProfile.UserProfile", "UserProfile")
                        .WithOne("CarDocumentation")
                        .HasForeignKey("KrakenStartup.CarDocumentations.CarDocumentation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KrakenStartup.ParkingSchedules.ParkingSchedule", b =>
                {
                    b.HasOne("KrakenStartup.Parkings.Parking", "Parking")
                        .WithMany("ParkingSchedule")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KrakenStartup.ParkingTransactions.ParkingTransaction", b =>
                {
                    b.HasOne("KrakenStartup.RentParkings.RentParking", "RentParking")
                        .WithMany("ParkingTransaction")
                        .HasForeignKey("RentParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.UsersCreditCards.UserCreditCard", "UserCreditCard")
                        .WithMany("ParkingTransaction")
                        .HasForeignKey("UserCreditCardId");

                    b.HasOne("KrakenStartup.UsersWallets.UserWallet", "UserWallet")
                        .WithMany("ParkingTransaction")
                        .HasForeignKey("UserWalletId");
                });

            modelBuilder.Entity("KrakenStartup.Parkings.Parking", b =>
                {
                    b.HasOne("KrakenStartup.AddressDocumentations.AddressDocumentation", "AddressDocumentation")
                        .WithMany("Parking")
                        .HasForeignKey("AddressDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.UsersWallets.UserWallet", "Wallet")
                        .WithMany("Parking")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KrakenStartup.RentParkings.RentParking", b =>
                {
                    b.HasOne("KrakenStartup.ParkingSchedules.ParkingSchedule", "ParkingSchedule")
                        .WithMany("RentParking")
                        .HasForeignKey("ParkingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.UsersProfile.UserProfile", "UserProfile")
                        .WithMany("RentParking")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.UsersVouchers.UserVoucher", "UserVoucher")
                        .WithMany("RentParking")
                        .HasForeignKey("UserVoucherId");
                });

            modelBuilder.Entity("KrakenStartup.UsersCreditCards.UserCreditCard", b =>
                {
                    b.HasOne("KrakenStartup.CreditCards.CreditCard", "CreditCard")
                        .WithMany("UserCreditCard")
                        .HasForeignKey("CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.UsersProfile.UserProfile", "UserProfile")
                        .WithMany("UserCreditCard")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KrakenStartup.UsersProfile.UserProfile", b =>
                {
                    b.HasOne("KrakenStartup.AddressDocumentations.AddressDocumentation", "AddressDocumentation")
                        .WithMany("UserProfile")
                        .HasForeignKey("AddressDocumentationId");

                    b.HasOne("KrakenStartup.DriverDocumentations.DriverDocumentation", "DriverDocumentation")
                        .WithOne("UserProfile")
                        .HasForeignKey("KrakenStartup.UsersProfile.UserProfile", "DriverDocumentationId");

                    b.HasOne("KrakenStartup.Identifications.Identification", "Identification")
                        .WithOne("UserProfile")
                        .HasForeignKey("KrakenStartup.UsersProfile.UserProfile", "IdentificationId");

                    b.HasOne("KrakenStartup.UsersWallets.UserWallet", "UserWallet")
                        .WithOne("UserProfile")
                        .HasForeignKey("KrakenStartup.UsersProfile.UserProfile", "UserWalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KrakenStartup.UsersVouchers.UserVoucher", b =>
                {
                    b.HasOne("KrakenStartup.UsersProfile.UserProfile", "UserProfile")
                        .WithMany("UserVoucher")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrakenStartup.Vouchers.Voucher", "Voucher")
                        .WithMany("UserVoucher")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
