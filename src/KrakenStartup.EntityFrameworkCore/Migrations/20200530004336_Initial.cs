using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KrakenStartup.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESSDOCUMENTATION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Latitude = table.Column<string>(maxLength: 10, nullable: false),
                    Longitude = table.Column<string>(maxLength: 10, nullable: false),
                    StreetName = table.Column<string>(maxLength: 100, nullable: false),
                    AddressNumber = table.Column<string>(maxLength: 5, nullable: false),
                    Complement = table.Column<string>(maxLength: 50, nullable: true),
                    CountryName = table.Column<string>(maxLength: 50, nullable: false),
                    CityName = table.Column<string>(maxLength: 50, nullable: false),
                    NeighborhoodName = table.Column<string>(maxLength: 50, nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSDOCUMENTATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CREDITCARD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Credential = table.Column<string>(maxLength: 255, nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDITCARD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DRIVERDOCUMENTATION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ValidTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(maxLength: 255, nullable: false),
                    StorageId = table.Column<string>(maxLength: 255, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVERDOCUMENTATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDENTIFICATION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ValidTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(maxLength: 255, nullable: false),
                    StorageId = table.Column<string>(maxLength: 255, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTIFICATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERWALLET",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    CurrencyType = table.Column<byte>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERWALLET", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VOUCHER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    PercentageValue = table.Column<int>(nullable: true),
                    MinimumPurchaseValue = table.Column<int>(nullable: true),
                    ValidTime = table.Column<DateTime>(nullable: true),
                    SingleUse = table.Column<bool>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOUCHER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PARKING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    WalletId = table.Column<int>(nullable: false),
                    AddressDocumentId = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARKING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PARKING_ADDRESSDOCUMENTATION_AddressDocumentId",
                        column: x => x.AddressDocumentId,
                        principalTable: "ADDRESSDOCUMENTATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARKING_USERWALLET_WalletId",
                        column: x => x.WalletId,
                        principalTable: "USERWALLET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERPROFILE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneRegion = table.Column<byte>(nullable: false),
                    Language = table.Column<byte>(nullable: false),
                    MultiFactor = table.Column<bool>(nullable: false),
                    LastFailedLogin = table.Column<byte>(nullable: false),
                    FingerPrint = table.Column<string>(maxLength: 255, nullable: true),
                    IdentificationId = table.Column<int>(nullable: true),
                    DriverDocumentationId = table.Column<int>(nullable: true),
                    AddressDocumentationId = table.Column<int>(nullable: true),
                    UserWalletId = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERPROFILE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERPROFILE_ADDRESSDOCUMENTATION_AddressDocumentationId",
                        column: x => x.AddressDocumentationId,
                        principalTable: "ADDRESSDOCUMENTATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERPROFILE_DRIVERDOCUMENTATION_DriverDocumentationId",
                        column: x => x.DriverDocumentationId,
                        principalTable: "DRIVERDOCUMENTATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERPROFILE_IDENTIFICATION_IdentificationId",
                        column: x => x.IdentificationId,
                        principalTable: "IDENTIFICATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERPROFILE_USERWALLET_UserWalletId",
                        column: x => x.UserWalletId,
                        principalTable: "USERWALLET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PARKINGSCHEDULE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(nullable: false),
                    Repetition = table.Column<byte>(nullable: false),
                    ValidTime = table.Column<DateTime>(nullable: true),
                    ParkingId = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARKINGSCHEDULE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PARKINGSCHEDULE_PARKING_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "PARKING",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARDOCUMENTATION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ValidTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(maxLength: 255, nullable: false),
                    StorageId = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARDOCUMENTATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARDOCUMENTATION_USERPROFILE_UserId",
                        column: x => x.UserId,
                        principalTable: "USERPROFILE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERCREDITCARD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    ValidTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreditCardId = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERCREDITCARD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERCREDITCARD_CREDITCARD_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CREDITCARD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERCREDITCARD_USERPROFILE_UserId",
                        column: x => x.UserId,
                        principalTable: "USERPROFILE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERVOUCHER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(nullable: false),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    VoucherId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERVOUCHER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERVOUCHER_USERPROFILE_UserId",
                        column: x => x.UserId,
                        principalTable: "USERPROFILE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERVOUCHER_VOUCHER_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "VOUCHER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RENTPARKING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(nullable: false),
                    PercentageTime = table.Column<byte>(nullable: false),
                    Day = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    ParkingScheduleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserVoucherId = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RENTPARKING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RENTPARKING_PARKINGSCHEDULE_ParkingScheduleId",
                        column: x => x.ParkingScheduleId,
                        principalTable: "PARKINGSCHEDULE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RENTPARKING_USERPROFILE_UserId",
                        column: x => x.UserId,
                        principalTable: "USERPROFILE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RENTPARKING_USERVOUCHER_UserVoucherId",
                        column: x => x.UserVoucherId,
                        principalTable: "USERVOUCHER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARKINGTRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(nullable: false),
                    TransactionInfo = table.Column<string>(maxLength: 255, nullable: true),
                    AmountMoney = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    RentParkingId = table.Column<int>(nullable: false),
                    UserWalletId = table.Column<int>(nullable: true),
                    UserCreditCardId = table.Column<int>(nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARKINGTRANSACTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PARKINGTRANSACTION_RENTPARKING_RentParkingId",
                        column: x => x.RentParkingId,
                        principalTable: "RENTPARKING",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARKINGTRANSACTION_USERCREDITCARD_UserCreditCardId",
                        column: x => x.UserCreditCardId,
                        principalTable: "USERCREDITCARD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PARKINGTRANSACTION_USERWALLET_UserWalletId",
                        column: x => x.UserWalletId,
                        principalTable: "USERWALLET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARDOCUMENTATION_UserId",
                table: "CARDOCUMENTATION",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARKING_AddressDocumentId",
                table: "PARKING",
                column: "AddressDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PARKING_WalletId",
                table: "PARKING",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_PARKINGSCHEDULE_ParkingId",
                table: "PARKINGSCHEDULE",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_PARKINGTRANSACTION_RentParkingId",
                table: "PARKINGTRANSACTION",
                column: "RentParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_PARKINGTRANSACTION_UserCreditCardId",
                table: "PARKINGTRANSACTION",
                column: "UserCreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PARKINGTRANSACTION_UserWalletId",
                table: "PARKINGTRANSACTION",
                column: "UserWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_RENTPARKING_ParkingScheduleId",
                table: "RENTPARKING",
                column: "ParkingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_RENTPARKING_UserId",
                table: "RENTPARKING",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RENTPARKING_UserVoucherId",
                table: "RENTPARKING",
                column: "UserVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_USERCREDITCARD_CreditCardId",
                table: "USERCREDITCARD",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_USERCREDITCARD_UserId",
                table: "USERCREDITCARD",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USERPROFILE_AddressDocumentationId",
                table: "USERPROFILE",
                column: "AddressDocumentationId");

            migrationBuilder.CreateIndex(
                name: "IX_USERPROFILE_DriverDocumentationId",
                table: "USERPROFILE",
                column: "DriverDocumentationId",
                unique: true,
                filter: "[DriverDocumentationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USERPROFILE_IdentificationId",
                table: "USERPROFILE",
                column: "IdentificationId",
                unique: true,
                filter: "[IdentificationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USERPROFILE_UserWalletId",
                table: "USERPROFILE",
                column: "UserWalletId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERVOUCHER_UserId",
                table: "USERVOUCHER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USERVOUCHER_VoucherId",
                table: "USERVOUCHER",
                column: "VoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARDOCUMENTATION");

            migrationBuilder.DropTable(
                name: "PARKINGTRANSACTION");

            migrationBuilder.DropTable(
                name: "RENTPARKING");

            migrationBuilder.DropTable(
                name: "USERCREDITCARD");

            migrationBuilder.DropTable(
                name: "PARKINGSCHEDULE");

            migrationBuilder.DropTable(
                name: "USERVOUCHER");

            migrationBuilder.DropTable(
                name: "CREDITCARD");

            migrationBuilder.DropTable(
                name: "PARKING");

            migrationBuilder.DropTable(
                name: "USERPROFILE");

            migrationBuilder.DropTable(
                name: "VOUCHER");

            migrationBuilder.DropTable(
                name: "ADDRESSDOCUMENTATION");

            migrationBuilder.DropTable(
                name: "DRIVERDOCUMENTATION");

            migrationBuilder.DropTable(
                name: "IDENTIFICATION");

            migrationBuilder.DropTable(
                name: "USERWALLET");
        }
    }
}
