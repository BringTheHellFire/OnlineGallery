using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGallery.Data.Migrations
{
    public partial class AddUserIdToFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Folders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Folders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CreatedByUserId",
                table: "Folders",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_AspNetUsers_CreatedByUserId",
                table: "Folders",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_AspNetUsers_CreatedByUserId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_CreatedByUserId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Folders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Folders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
