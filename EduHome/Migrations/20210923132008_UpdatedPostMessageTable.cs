using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class UpdatedPostMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "PostMessages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostMessages_CourseId",
                table: "PostMessages",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMessages_Courses_CourseId",
                table: "PostMessages",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMessages_Courses_CourseId",
                table: "PostMessages");

            migrationBuilder.DropIndex(
                name: "IX_PostMessages_CourseId",
                table: "PostMessages");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "PostMessages");
        }
    }
}
