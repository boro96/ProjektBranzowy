using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektBranzowy.Migrations
{
    public partial class add_ScheduleRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleRooms",
                columns: table => new
                {
                    ScheduleRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    Finish = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRooms", x => x.ScheduleRoomId);
                    table.ForeignKey(
                        name: "FK_ScheduleRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRooms_RoomId",
                table: "ScheduleRooms",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleRooms");
        }
    }
}
