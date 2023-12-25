using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCore.UI.Migrations
{
    public partial class supplierTableAddCountryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Suppliers");
        }
    }
}
