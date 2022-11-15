using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGallery.Data.Migrations
{
    public partial class AddImagePathToUserArtwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "UserArtworks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "UserArtworks");
        }
    }
}
