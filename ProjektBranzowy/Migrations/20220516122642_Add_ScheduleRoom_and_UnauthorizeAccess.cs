using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektBranzowy.Migrations
{
    public partial class Add_ScheduleRoom_and_UnauthorizeAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnauthorizedAccess",
                columns: table => new
                {
                    UnauthorizedAccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    In = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Out = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnauthorizedAccess", x => x.UnauthorizedAccessId);
                    table.ForeignKey(
                        name: "FK_UnauthorizedAccess_People_UserId",
                        column: x => x.UserId,
                        principalTable: "People",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnauthorizedAccess_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnauthorizedAccess_RoomId",
                table: "UnauthorizedAccess",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UnauthorizedAccess_UserId",
                table: "UnauthorizedAccess",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnauthorizedAccess");
        }
    }
}
