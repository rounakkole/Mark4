using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mark4.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationDbContext_ApplicationUser_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioTable1_UserTable1_UserId",
                table: "PortfolioTable1");

            migrationBuilder.DropForeignKey(
                name: "FK_SetupTable1_UserTable1_UserId",
                table: "SetupTable1");

            migrationBuilder.DropTable(
                name: "UserTable1");

            migrationBuilder.AddColumn<int>(
                name: "ExchangeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetupId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ExchangeTable1_ExchangeId",
                table: "AspNetUsers",
                column: "ExchangeId",
                principalTable: "ExchangeTable1",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioTable1_AspNetUsers_UserId",
                table: "PortfolioTable1",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetupTable1_AspNetUsers_UserId",
                table: "SetupTable1",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ExchangeTable1_ExchangeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioTable1_AspNetUsers_UserId",
                table: "PortfolioTable1");

            migrationBuilder.DropForeignKey(
                name: "FK_SetupTable1_AspNetUsers_UserId",
                table: "SetupTable1");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ExchangeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExchangeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SetupId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserTable1",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExchangeId = table.Column<int>(type: "int", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetupId = table.Column<int>(type: "int", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_UserTable1_ExchangeId",
                table: "UserTable1",
                column: "ExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioTable1_UserTable1_UserId",
                table: "PortfolioTable1",
                column: "UserId",
                principalTable: "UserTable1",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetupTable1_UserTable1_UserId",
                table: "SetupTable1",
                column: "UserId",
                principalTable: "UserTable1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
