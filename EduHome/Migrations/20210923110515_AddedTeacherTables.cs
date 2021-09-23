using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class AddedTeacherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Footer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "Footer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Footer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vimeo",
                table: "Footer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(nullable: true),
                    Professional = table.Column<string>(nullable: true),
                    AboutTeacher = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Hobbies = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Language = table.Column<int>(nullable: false),
                    Design = table.Column<int>(nullable: false),
                    Development = table.Column<int>(nullable: false),
                    TeamLeader = table.Column<int>(nullable: false),
                    Innovation = table.Column<int>(nullable: false),
                    Communication = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Vimeo = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Footer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Facebook", "Pinterest", "Twitter", "Vimeo" },
                values: new object[] { "facebook.com", "pinterest.com", "twitter.com", "vimeo.com" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AboutTeacher", "Communication", "CourseId", "Design", "Development", "Email", "Experience", "Facebook", "Faculty", "Fullname", "Hobbies", "Innovation", "Language", "Phone", "Pinterest", "Professional", "Skype", "TeamLeader", "Twitter", "Vimeo" },
                values: new object[] { 1, "I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human happiness pcias unde omnis iste natus error sit voluptatem accusantium ue laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quas i architeo beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas", 95, 1, 95, 85, " stuart@eduhome.com", 7, "facebook.com", "Din, Department of Micro Biology", "STUART KELVIN", "music, travelling, catching fish", 85, 85, "(+125) 5896 548 9874", "pinterest.com", "Associate Professor", "stuart.k", 90, "twitter.com", "vimeo.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Footer");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "Footer");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Footer");

            migrationBuilder.DropColumn(
                name: "Vimeo",
                table: "Footer");

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Footer_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "FooterId", "Icon", "Link", "Name" },
                values: new object[,]
                {
                    { 1, 1, "zmdi zmdi-facebook", "facebook.com", "facebook" },
                    { 2, 1, "zmdi zmdi-pinterest", "pinterest.com", "pinterest" },
                    { 3, 1, "zmdi zmdi-vimeo", "vimeo.com", "vimeo" },
                    { 4, 1, "zmdi zmdi-twitter", "twitter.com", "twitter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_FooterId",
                table: "SocialLinks",
                column: "FooterId");
        }
    }
}
