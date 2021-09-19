using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdatePostMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailBody",
                table: "PostMessages");

            migrationBuilder.DropColumn(
                name: "MailHeading",
                table: "PostMessages");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "PostMessages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PostMessages",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "PostMessages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PostMessages");

            migrationBuilder.AddColumn<string>(
                name: "MailBody",
                table: "PostMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MailHeading",
                table: "PostMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
