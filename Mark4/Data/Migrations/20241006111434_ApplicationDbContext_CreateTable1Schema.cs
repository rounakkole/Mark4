using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mark4.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationDbContext_CreateTable1Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExSymbolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExSymbolDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExDefaultIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeTable1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeId = table.Column<int>(type: "int", nullable: false),
                    WatchlistId = table.Column<int>(type: "int", nullable: true),
                    InSymbolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InSymbolDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InSector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRisky = table.Column<bool>(type: "bit", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mark3mIx = table.Column<int>(type: "int", nullable: false),
                    Mark1yIx = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InMarketCap = table.Column<int>(type: "int", nullable: false),
                    InEventHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InEventLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentTable1_ExchangeTable1_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "ExchangeTable1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTable1",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SetupId = table.Column<int>(type: "int", nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTable1_ExchangeTable1_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "ExchangeTable1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeedTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntervalNum = table.Column<int>(type: "int", nullable: false),
                    FeedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedTable1_InstrumentTable1_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "InstrumentTable1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WatchlistTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    Mark3mIx = table.Column<int>(type: "int", nullable: false),
                    Mark1yIx = table.Column<int>(type: "int", nullable: false),
                    RandomNum = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchlistTable1_InstrumentTable1_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "InstrumentTable1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NewQuantity = table.Column<int>(type: "int", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioTable1_InstrumentTable1_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "InstrumentTable1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PortfolioTable1_UserTable1_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SetupTable1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportExecutionNum = table.Column<int>(type: "int", nullable: false),
                    WatchlistNum = table.Column<int>(type: "int", nullable: false),
                    RandomNum = table.Column<int>(type: "int", nullable: false),
                    IntervalNum = table.Column<int>(type: "int", nullable: false),
                    PeriodNum = table.Column<int>(type: "int", nullable: false),
                    OffsetNum = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupTable1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetupTable1_UserTable1_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedTable1_InstrumentId",
                table: "FeedTable1",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTable1_ExchangeId",
                table: "InstrumentTable1",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioTable1_InstrumentId",
                table: "PortfolioTable1",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioTable1_UserId",
                table: "PortfolioTable1",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupTable1_UserId",
                table: "SetupTable1",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTable1_ExchangeId",
                table: "UserTable1",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistTable1_InstrumentId",
                table: "WatchlistTable1",
                column: "InstrumentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedTable1");

            migrationBuilder.DropTable(
                name: "PortfolioTable1");

            migrationBuilder.DropTable(
                name: "SetupTable1");

            migrationBuilder.DropTable(
                name: "WatchlistTable1");

            migrationBuilder.DropTable(
                name: "UserTable1");

            migrationBuilder.DropTable(
                name: "InstrumentTable1");

            migrationBuilder.DropTable(
                name: "ExchangeTable1");
        }
    }
}
