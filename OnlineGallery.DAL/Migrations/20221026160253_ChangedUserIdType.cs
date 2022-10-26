using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGallery.Data.Migrations
{
    public partial class ChangedUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArtworks_AspNetUsers_UserId1",
                table: "UserArtworks");

            migrationBuilder.DropIndex(
                name: "IX_UserArtworks_UserId1",
                table: "UserArtworks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserArtworks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserArtworks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserArtworks_UserId",
                table: "UserArtworks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArtworks_AspNetUsers_UserId",
                table: "UserArtworks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArtworks_AspNetUsers_UserId",
                table: "UserArtworks");

            migrationBuilder.DropIndex(
                name: "IX_UserArtworks_UserId",
                table: "UserArtworks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserArtworks",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserArtworks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserArtworks_UserId1",
                table: "UserArtworks",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArtworks_AspNetUsers_UserId1",
                table: "UserArtworks",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
