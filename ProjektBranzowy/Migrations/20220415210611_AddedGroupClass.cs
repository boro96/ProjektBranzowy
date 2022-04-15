using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektBranzowy.Migrations
{
    public partial class AddedGroupClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_GroupId",
                table: "People",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Groups_GroupId",
                table: "People",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Groups_GroupId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_People_GroupId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "People");
        }
    }
}
