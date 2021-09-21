using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class AddedFooterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: true),
                    Slogan = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    Copyright = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FooterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Footer_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    FooterId = table.Column<int>(nullable: false)
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
                table: "Footer",
                columns: new[] { "Id", "Address", "Copyright", "Email", "Logo", "Slogan", "website" },
                values: new object[] { 1, "City, Roadno 785 New York", "<p>Copyright © <a href='#' target='_blank'>HasTech</a> 2017. All Right Reserved By Hastech.</p>", "info@eduhome.com", "footer-logo.png", "I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system.", "www.eduhome.com" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "FooterId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "+880 548 986 898 87" },
                    { 2, 1, "+880 659 785 658 98" }
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
                name: "IX_Phones_FooterId",
                table: "Phones",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_FooterId",
                table: "SocialLinks",
                column: "FooterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Footer");
        }
    }
}
