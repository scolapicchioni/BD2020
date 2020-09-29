using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoSharingApplication.Web.MVC.Migrations
{
    public partial class PhotoPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Photo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Photo");
        }
    }
}
