﻿// <auto-generated />
using System;
using EduHome.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduHome.Migrations
{
    [DbContext(typeof(EduhomeDbContext))]
    partial class EduhomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EduHome.Models.Entity.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CSS Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Political Science"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Micro Biology"
                        },
                        new
                        {
                            Id = 4,
                            Name = "HTML5 & CSS3"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Web Design"
                        },
                        new
                        {
                            Id = 6,
                            Name = "PHP"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Course", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EduHome.Models.Entity.CourseTheme", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CourseThemes");
                });

            modelBuilder.Entity("EduHome.Models.Entity.CourseThemeCourse", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseThemeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseThemeId");

                    b.ToTable("CourseThemeCourses");
                });

            modelBuilder.Entity("EduHome.Models.Entity.Event", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ByWhom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("TimeIntervalId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TimeIntervalId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Cristal Centre, 254 New Yourk",
                            ByWhom = "Emin",
                            CategoryId = 1,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "event1.jpg",
                            IsDeleted = false,
                            TimeIntervalId = 1,
                            Title = "I'm Smartest man"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Cristal Centre, 254 New Yourk",
                            ByWhom = "Cavid",
                            CategoryId = 1,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "event2.jpg",
                            IsDeleted = false,
                            TimeIntervalId = 2,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Cristal Centre, 254 New Yourk",
                            ByWhom = "Elvin",
                            CategoryId = 1,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "event3.jpg",
                            IsDeleted = false,
                            TimeIntervalId = 1,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Cristal Centre, 254 New Yourk",
                            ByWhom = "Serxan",
                            CategoryId = 3,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "event5.jpg",
                            IsDeleted = false,
                            TimeIntervalId = 2,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.EventSpeaker", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("EventSpeakers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            SpeakerId = 1
                        },
                        new
                        {
                            Id = 2,
                            EventId = 1,
                            SpeakerId = 2
                        },
                        new
                        {
                            Id = 3,
                            EventId = 2,
                            SpeakerId = 1
                        },
                        new
                        {
                            Id = 4,
                            EventId = 3,
                            SpeakerId = 2
                        },
                        new
                        {
                            Id = 5,
                            EventId = 4,
                            SpeakerId = 1
                        },
                        new
                        {
                            Id = 6,
                            EventId = 4,
                            SpeakerId = 2
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Footer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slogan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Footer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "City, Roadno 785 New York",
                            Copyright = "<p>Copyright © <a href='#' target='_blank'>HasTech</a> 2017. All Right Reserved By Hastech.</p>",
                            Email = "info@eduhome.com",
                            Logo = "footer-logo.png",
                            Slogan = "I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system.",
                            website = "www.eduhome.com"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Header", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Header");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Logo = "logo2.png",
                            Phone = "+880 5698 598 6587",
                            Text = "HAVE ANY QUESTION ?"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Phone", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FooterId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FooterId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FooterId = 1,
                            PhoneNumber = "+880 548 986 898 87"
                        },
                        new
                        {
                            Id = 2,
                            FooterId = 1,
                            PhoneNumber = "+880 659 785 658 98"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Post", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ByWhom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ByWhom = "Orxan",
                            CategoryId = 1,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "blog8.jpg",
                            IsDeleted = false,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        },
                        new
                        {
                            Id = 2,
                            ByWhom = "Cavid",
                            CategoryId = 2,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "blog2.jpg",
                            IsDeleted = false,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        },
                        new
                        {
                            Id = 3,
                            ByWhom = "Elvin",
                            CategoryId = 1,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "blog5.jpg",
                            IsDeleted = false,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        },
                        new
                        {
                            Id = 4,
                            ByWhom = "Serxan",
                            CategoryId = 3,
                            Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p><p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p><p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                            Image = "blog7.jpg",
                            IsDeleted = false,
                            Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.PostMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PostId");

                    b.ToTable("PostMessages");
                });

            modelBuilder.Entity("EduHome.Models.Entity.SocialLink", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FooterId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FooterId");

                    b.ToTable("SocialLinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FooterId = 1,
                            Icon = "zmdi zmdi-facebook",
                            Link = "facebook.com",
                            Name = "facebook"
                        },
                        new
                        {
                            Id = 2,
                            FooterId = 1,
                            Icon = "zmdi zmdi-pinterest",
                            Link = "pinterest.com",
                            Name = "pinterest"
                        },
                        new
                        {
                            Id = 3,
                            FooterId = 1,
                            Icon = "zmdi zmdi-vimeo",
                            Link = "vimeo.com",
                            Name = "vimeo"
                        },
                        new
                        {
                            Id = 4,
                            FooterId = 1,
                            Icon = "zmdi zmdi-twitter",
                            Link = "twitter.com",
                            Name = "twitter"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.Speaker", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Professional")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Speakers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fullname = "Anthony Smith",
                            Image = "speaker1.jpg",
                            Professional = "CEO, Hastech"
                        },
                        new
                        {
                            Id = 2,
                            Fullname = "Lucy Rose",
                            Image = "speaker2.jpg",
                            Professional = "Developer, STD"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.TimeInterval", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TimeIntervals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "9:30am - 4:45pm"
                        },
                        new
                        {
                            Id = 2,
                            Name = " 9:30am - 4:45pm"
                        });
                });

            modelBuilder.Entity("EduHome.Models.Entity.CourseThemeCourse", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Category", "Category")
                        .WithMany("CourseThemeCourses")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EduHome.Models.Entity.Course", "Course")
                        .WithMany("CourseThemeCourses")
                        .HasForeignKey("CourseId");

                    b.HasOne("EduHome.Models.Entity.CourseTheme", "CourseTheme")
                        .WithMany("CourseThemeCourses")
                        .HasForeignKey("CourseThemeId");
                });

            modelBuilder.Entity("EduHome.Models.Entity.Event", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EduHome.Models.Entity.TimeInterval", "TimeInterval")
                        .WithMany()
                        .HasForeignKey("TimeIntervalId");
                });

            modelBuilder.Entity("EduHome.Models.Entity.EventSpeaker", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Event", "Event")
                        .WithMany("EventSpeakers")
                        .HasForeignKey("EventId");

                    b.HasOne("EduHome.Models.Entity.Speaker", "Speaker")
                        .WithMany("EventSpeakers")
                        .HasForeignKey("SpeakerId");
                });

            modelBuilder.Entity("EduHome.Models.Entity.Phone", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Footer", "Footer")
                        .WithMany("Phones")
                        .HasForeignKey("FooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduHome.Models.Entity.Post", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EduHome.Models.Entity.PostMessage", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Event", "Event")
                        .WithMany("PostMessages")
                        .HasForeignKey("EventId");

                    b.HasOne("EduHome.Models.Entity.Post", "Post")
                        .WithMany("PostMessages")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("EduHome.Models.Entity.SocialLink", b =>
                {
                    b.HasOne("EduHome.Models.Entity.Footer", "Footer")
                        .WithMany("SocialLinks")
                        .HasForeignKey("FooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
