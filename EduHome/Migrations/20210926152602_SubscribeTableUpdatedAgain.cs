using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SubscribeTableUpdatedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscribes",
                columns: new[] { "Id", "Text", "Title" },
                values: new object[] { 1, "I must explain to you how all this mistaken idea", "SUBSCRIBE OUR NEWSLETTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscribes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
