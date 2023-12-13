using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCore.UI.Migrations
{
    public partial class writerTableProfileImagePathAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Writers");
        }
    }
}
