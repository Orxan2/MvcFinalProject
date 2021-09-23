using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillLevel = table.Column<string>(maxLength: 25, nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    LessonTime = table.Column<int>(nullable: false),
                    Language = table.Column<string>(maxLength: 10, nullable: false),
                    Assesments = table.Column<string>(maxLength: 25, nullable: false),
                    StudentQuantity = table.Column<int>(nullable: false),
                    Fee = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

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
                name: "Header",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 100, nullable: false),
                    Professional = table.Column<string>(maxLength: 50, nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeIntervals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    Street = table.Column<string>(maxLength: 50, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    HowToApply = table.Column<string>(nullable: true),
                    AboutCourse = table.Column<string>(nullable: true),
                    Certification = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    FeatureId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ByWhom = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TimeIntervalId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_TimeIntervals_TimeIntervalId",
                        column: x => x.TimeIntervalId,
                        principalTable: "TimeIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ByWhom = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    Details = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSpeakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    SpeakerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpeakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(maxLength: 25, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsReadable = table.Column<bool>(nullable: false, defaultValue: false),
                    PostId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMessages_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostMessages_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostMessages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CSS Engineering" },
                    { 2, "Political Science" },
                    { 3, "Micro Biology" },
                    { 4, "HTML5 & CSS3" },
                    { 5, "Web Design" },
                    { 6, "PHP" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Assesments", "Duration", "Fee", "Language", "LessonTime", "SkillLevel", "StudentQuantity" },
                values: new object[] { 1, "Self", 6, 789.0, "English", 3, "All", 420 });

            migrationBuilder.InsertData(
                table: "Footer",
                columns: new[] { "Id", "Address", "Copyright", "Email", "Logo", "Slogan", "website" },
                values: new object[] { 1, "City, Roadno 785 New York", "<p>Copyright © <a href='#' target='_blank'>HasTech</a> 2017. All Right Reserved By Hastech.</p>", "info@eduhome.com", "footer-logo.png", "I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system.", "www.eduhome.com" });

            migrationBuilder.InsertData(
                table: "Header",
                columns: new[] { "Id", "Logo", "Phone", "Text" },
                values: new object[] { 1, "logo2.png", "+880 5698 598 6587", "HAVE ANY QUESTION ?" });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Fullname", "Image", "Professional" },
                values: new object[,]
                {
                    { 1, "Anthony Smith", "speaker1.jpg", "CEO, Hastech" },
                    { 2, "Lucy Rose", "speaker2.jpg", "Developer, STD" }
                });

            migrationBuilder.InsertData(
                table: "TimeIntervals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "9:30am - 4:45pm" },
                    { 2, " 9:30am - 4:45pm" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ContactId", "Image", "Street" },
                values: new object[,]
                {
                    { 1, "New Yourk City", 1, "contact1.png", "135, First Lane, City Street" },
                    { 2, "Philadelphia", 1, "contact2.png", "135, First Lane, City Street" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AboutCourse", "CategoryId", "Certification", "FeatureId", "HowToApply", "Image", "Text", "Title" },
                values: new object[] { 1, "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss", 1, "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss", 1, "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss", "course1.jpg", "I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human happiness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui", "CSE ENGINEERING" });

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

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Address", "ByWhom", "CourseId", "Details", "Image", "IsDeleted", "TimeIntervalId", "Title" },
                values: new object[,]
                {
                    { 1, "Cristal Centre, 254 New Yourk", "Emin", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "event1.jpg", false, 1, "I'm Smartest man" },
                    { 2, "Cristal Centre, 254 New Yourk", "Cavid", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "event2.jpg", false, 2, "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" },
                    { 3, "Cristal Centre, 254 New Yourk", "Elvin", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "event3.jpg", false, 1, "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" },
                    { 4, "Cristal Centre, 254 New Yourk", "Serxan", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "event5.jpg", false, 2, "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "ByWhom", "CourseId", "Details", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "Orxan", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "blog8.jpg", "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" },
                    { 2, "Cavid", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "blog2.jpg", "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" },
                    { 3, "Elvin", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "blog5.jpg", "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" },
                    { 4, "Serxan", 1, "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>", "blog7.jpg", "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA" }
                });

            migrationBuilder.InsertData(
                table: "EventSpeakers",
                columns: new[] { "Id", "EventId", "SpeakerId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 3, 2 },
                    { 5, 4, 1 },
                    { 6, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FeatureId",
                table: "Courses",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CourseId",
                table: "Events",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimeIntervalId",
                table: "Events",
                column: "TimeIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_EventId",
                table: "EventSpeakers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_SpeakerId",
                table: "EventSpeakers",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_FooterId",
                table: "Phones",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMessages_ContactId",
                table: "PostMessages",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMessages_EventId",
                table: "PostMessages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMessages_PostId",
                table: "PostMessages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CourseId",
                table: "Posts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_FooterId",
                table: "SocialLinks",
                column: "FooterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "EventSpeakers");

            migrationBuilder.DropTable(
                name: "Header");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PostMessages");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Footer");

            migrationBuilder.DropTable(
                name: "TimeIntervals");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
