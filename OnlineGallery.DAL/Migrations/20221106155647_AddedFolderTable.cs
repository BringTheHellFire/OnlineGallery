using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGallery.Data.Migrations
{
    public partial class AddedFolderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "UserArtworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserArtworks_FolderId",
                table: "UserArtworks",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArtworks_Folders_FolderId",
                table: "UserArtworks",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArtworks_Folders_FolderId",
                table: "UserArtworks");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_UserArtworks_FolderId",
                table: "UserArtworks");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "UserArtworks");
        }
    }
}
