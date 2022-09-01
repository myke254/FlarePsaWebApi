using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flare.Repo.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ListingModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "ListingModel",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
