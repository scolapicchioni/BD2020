using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoSharingApplication.Web.MVC.Migrations
{
    public partial class PhotoUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Photo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Photo");
        }
    }
}
