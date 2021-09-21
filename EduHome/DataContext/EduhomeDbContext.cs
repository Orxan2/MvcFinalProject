using EduHome.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DataContext
{
    public class EduhomeDbContext:DbContext
    {
        public EduhomeDbContext(DbContextOptions<EduhomeDbContext> options):base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTheme> CourseThemes { get; set; }
        public DbSet<CourseThemeCourse> CourseThemeCourses { get; set; }
        public DbSet<PostMessage> PostMessages { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Header> Header { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().
                Property(p => p.Date).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            modelBuilder.Entity<Post>().
               Property(p => p.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Category>(e => e.HasData(
                new Category
                {
                    Id = 1,
                    Name = "CSS Engineering"
                },
                new Category
                {
                    Id = 2,
                    Name = "Political Science"
                },
                 new Category
                 {
                     Id = 3,
                     Name = "Micro Biology"
                 },
                new Category
                {
                    Id = 4,
                    Name = "HTML5 & CSS3"
                },
                 new Category
                 {
                     Id = 5,
                     Name = "Web Design"
                 },
                   new Category
                   {
                       Id = 6,
                       Name = "PHP"
                   }
                )
            );

            modelBuilder.Entity<Post>(e => e.HasData(
               new Post
               {
                   Id = 1,
                   ByWhom = "Orxan",
                   Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                   Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                   "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                   CategoryId = 1,
                   Image = "blog1.jpg"
               },
              new Post
              {
                  Id = 2,
                  ByWhom = "Cavid",
                  Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                  Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                   "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                  CategoryId = 2,
                  Image = "blog2.jpg"
              },
              new Post
              {
                  Id = 3,
                  ByWhom = "Elvin",
                  Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                  Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                   "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                  CategoryId = 1,
                  Image = "blog3.jpg"
              },
              new Post
              {
                  Id = 4,
                  ByWhom = "Serxan",
                  Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                  Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                   "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                   "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                  CategoryId = 3,
                  Image = "blog4.jpg"

              }
               )
           );

            modelBuilder.Entity<Speaker>(e => e.HasData(
               new Speaker
               {
                   Id = 1,
                  Fullname = "Anthony Smith" ,
                  Professional = "CEO, Hastech",
                  Image = "speaker1.jpg"
               },
               new Speaker
               {
                   Id = 2,
                   Fullname = "Lucy Rose",
                   Professional = "Developer, STD",
                   Image = "speaker2.jpg"
               })
           );

            modelBuilder.Entity<TimeInterval>(e => e.HasData(
               new TimeInterval
               {
                   Id = 1,
                  Name = "9:30am - 4:45pm"
               },
               new TimeInterval
               {
                   Id = 2,
                   Name = " 9:30am - 4:45pm"                   
               })
           );
            modelBuilder.Entity<Event>(e => e.HasData(
              new Event
              {
                  Id = 1,
                  ByWhom = "Emin",
                  Title = "I'm Smartest man",
                  Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                  "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                  CategoryId = 1,
                  Image = "event1.jpg",
                  TimeIntervalId = 1,
                  Address = "Cristal Centre, 254 New Yourk"

              },
             new Event
             {
                 Id = 2,
                 ByWhom = "Cavid",
                 Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                 Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                  "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                 CategoryId = 1,
                 Image = "event2.jpg",
                 TimeIntervalId = 2,
                 Address = "Cristal Centre, 254 New Yourk"
             },
             new Event
             {
                 Id = 3,
                 ByWhom = "Elvin",
                 Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                 Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                  "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                 CategoryId = 1,
                 Image = "event3.jpg",
                 TimeIntervalId = 1,
                 Address = "Cristal Centre, 254 New Yourk"
             },
             new Event
             {
                 Id = 4,
                 ByWhom = "Serxan",
                 Title = "I MUST EXPLAIN TO YOU HOW ALL THIS A MISTAKEN IDEA",
                 Details = "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam volutatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui </p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam</p>" +
                  "<p class='quote'>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque la udantium, totam rem aperiam</p>" +
                  "<p>I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human haness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque sa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo emo enim ipsam</p>",
                 CategoryId = 3,
                 Image = "event5.jpg",
                 TimeIntervalId = 2,
                 Address = "Cristal Centre, 254 New Yourk"

             }
              )
          );
            modelBuilder.Entity<EventSpeaker>(e => e.HasData(
              new EventSpeaker
              {
                  Id = 1,
                  EventId = 1,
                  SpeakerId = 1
              },
              new EventSpeaker
              {
                  Id = 2,
                  EventId = 1,
                  SpeakerId = 2
              },
              new EventSpeaker
              {
                  Id = 3,
                  EventId = 2,
                  SpeakerId = 1
              },
              new EventSpeaker
              {
                  Id = 4,
                  EventId = 3,
                  SpeakerId = 2
              },
            new EventSpeaker
            {
                Id = 5,
                EventId = 4,
                SpeakerId = 1
            },
              new EventSpeaker
              {
                  Id = 6,
                  EventId = 4,
                  SpeakerId = 2
              })
          );
            modelBuilder.Entity<Phone>(e => e.HasData(
              new Phone
              {
                  Id = 1,
                 PhoneNumber = "+880 548 986 898 87",
                 FooterId = 1
              },
              new Phone
              {
                  Id = 2,
                  PhoneNumber = "+880 659 785 658 98",
                  FooterId = 1
              })
          );
            modelBuilder.Entity<SocialLink>(e => e.HasData(
             new SocialLink
             {
                 Id = 1,
                 Name = "facebook",
                 Icon = "zmdi zmdi-facebook",
                 Link = "facebook.com",
                 FooterId = 1
             },
            new SocialLink
            {
                Id = 2,
                Name = "pinterest",
                Icon = "zmdi zmdi-pinterest",
                Link = "pinterest.com",
                 FooterId = 1
            },
            new SocialLink
            {
                Id = 3,
                Name = "vimeo",
                Icon = "zmdi zmdi-vimeo",
                Link = "vimeo.com",
                 FooterId = 1
            },
            new SocialLink
            {
                Id = 4,
                Name = "twitter",
                Icon = "zmdi zmdi-twitter",
                Link = "twitter.com",
                FooterId = 1
            })
         );

            modelBuilder.Entity<Footer>(e => e.HasData(
              new Footer
              {
                  Id = 1,
                  Address = "City, Roadno 785 New York",
                  Copyright = "<p>Copyright © <a href='#' target='_blank'>HasTech</a> 2017. All Right Reserved By Hastech.</p>",
                  Email = "info@eduhome.com",
                  Logo = "footer-logo.png",
                  Slogan = "I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system.",
                  website = "www.eduhome.com"
              })
          );

            modelBuilder.Entity<Header>(e => e.HasData(
             new Header
             {
                 Id = 1,
                 Logo = "logo2.png",
                 Text = "HAVE ANY QUESTION ?",
                 Phone = "+880 5698 598 6587"
             })
         );
        }
    }
}
