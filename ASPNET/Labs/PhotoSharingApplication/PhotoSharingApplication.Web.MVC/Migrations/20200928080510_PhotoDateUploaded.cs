using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoSharingApplication.Web.MVC.Migrations
{
    public partial class PhotoDateUploaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUploaded",
                table: "Photo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUploaded",
                table: "Photo");
        }
    }
}
