using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table_Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresenterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Schedules_Table_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Table_Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table_Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Tickets_Table_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Table_Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table_Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CanManageUsers = table.Column<bool>(type: "bit", nullable: false),
                    CanManageConferences = table.Column<bool>(type: "bit", nullable: false),
                    CanManageOrders = table.Column<bool>(type: "bit", nullable: false),
                    LastLogins = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Admins_Table_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Table_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Orders_Table_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Table_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table_OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_OrderDetails_Table_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Table_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Table_OrderDetails_Table_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Table_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_Admins_UserId",
                table: "Table_Admins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_OrderDetails_OrderId",
                table: "Table_OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_OrderDetails_TicketId",
                table: "Table_OrderDetails",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Orders_UserId",
                table: "Table_Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Schedules_EventId",
                table: "Table_Schedules",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Tickets_EventId",
                table: "Table_Tickets",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table_Admins");

            migrationBuilder.DropTable(
                name: "Table_OrderDetails");

            migrationBuilder.DropTable(
                name: "Table_Schedules");

            migrationBuilder.DropTable(
                name: "Table_Orders");

            migrationBuilder.DropTable(
                name: "Table_Tickets");

            migrationBuilder.DropTable(
                name: "Table_Users");

            migrationBuilder.DropTable(
                name: "Table_Events");
        }
    }
}
