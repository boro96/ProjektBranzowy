using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektBranzowy.Migrations
{
    public partial class RemoveGroupColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "People",
                type: "char(6)",
                nullable: true);
        }
    }
}
