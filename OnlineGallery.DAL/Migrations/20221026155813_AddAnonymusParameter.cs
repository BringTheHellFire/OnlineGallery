using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGallery.Data.Migrations
{
    public partial class AddAnonymusParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anonymus",
                table: "UserArtworks",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anonymus",
                table: "UserArtworks");
        }
    }
}
