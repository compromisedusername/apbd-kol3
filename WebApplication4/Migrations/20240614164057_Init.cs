using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatStandards",
                columns: table => new
                {
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatStandards", x => x.IdBoatStandard);
                });

            migrationBuilder.CreateTable(
                name: "ClientCategory",
                columns: table => new
                {
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategory", x => x.IdClientCategory);
                });

            migrationBuilder.CreateTable(
                name: "Sallboat",
                columns: table => new
                {
                    IdSallboat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sallboat", x => x.IdSallboat);
                    table.ForeignKey(
                        name: "FK_Sallboat_BoatStandards_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandards",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_ClientCategory_IdClientCategory",
                        column: x => x.IdClientCategory,
                        principalTable: "ClientCategory",
                        principalColumn: "IdClientCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NumOfBoats = table.Column<int>(type: "int", nullable: false),
                    Fulfilled = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservation_BoatStandards_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandards",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationSallboat",
                columns: table => new
                {
                    ReservationsIdReservation = table.Column<int>(type: "int", nullable: false),
                    SallboatsIdSallboat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSallboat", x => new { x.ReservationsIdReservation, x.SallboatsIdSallboat });
                    table.ForeignKey(
                        name: "FK_ReservationSallboat_Reservation_ReservationsIdReservation",
                        column: x => x.ReservationsIdReservation,
                        principalTable: "Reservation",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ReservationSallboat_Sallboat_SallboatsIdSallboat",
                        column: x => x.SallboatsIdSallboat,
                        principalTable: "Sallboat",
                        principalColumn: "IdSallboat",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "BoatStandards",
                columns: new[] { "IdBoatStandard", "Level", "Name" },
                values: new object[] { 1, 1, "brak" });

            migrationBuilder.InsertData(
                table: "ClientCategory",
                columns: new[] { "IdClientCategory", "DiscountPerc", "Name" },
                values: new object[] { 1, 123123, "asdasd" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Birthday", "Email", "IdClientCategory", "LastName", "Name", "Pesel" },
                values: new object[] { 1, new DateTime(2024, 6, 14, 18, 40, 56, 897, DateTimeKind.Local).AddTicks(4819), "asdasd", 1, "lalsd", "name", "asdASD233" });

            migrationBuilder.InsertData(
                table: "Sallboat",
                columns: new[] { "IdSallboat", "Capacity", "Description", "IdBoatStandard", "Name", "Price" },
                values: new object[] { 1, 1, "asd", 1, "brak", 1 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "IdReservation", "CancelReason", "Capacity", "DateFrom", "DateTo", "Fulfilled", "IdBoatStandard", "IdClient", "NumOfBoats", "Price" },
                values: new object[] { 1, "basd", 1, new DateTime(2024, 6, 14, 18, 40, 56, 902, DateTimeKind.Local).AddTicks(2166), new DateTime(2024, 6, 14, 18, 40, 56, 902, DateTimeKind.Local).AddTicks(2591), true, 1, 1, 1, 1123 });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdClientCategory",
                table: "Client",
                column: "IdClientCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdBoatStandard",
                table: "Reservation",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdClient",
                table: "Reservation",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSallboat_SallboatsIdSallboat",
                table: "ReservationSallboat",
                column: "SallboatsIdSallboat");

            migrationBuilder.CreateIndex(
                name: "IX_Sallboat_IdBoatStandard",
                table: "Sallboat",
                column: "IdBoatStandard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationSallboat");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Sallboat");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "BoatStandards");

            migrationBuilder.DropTable(
                name: "ClientCategory");
        }
    }
}
