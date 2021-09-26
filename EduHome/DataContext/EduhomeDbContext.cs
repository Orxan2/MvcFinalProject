using EduHome.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DataContext
{
    public class EduhomeDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public EduhomeDbContext(DbContextOptions<EduhomeDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }        
        public DbSet<Feature> Features { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Post> Posts { get; set; }


        public DbSet<PostMessage> PostMessages { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<Teacher> Teachers { get; set; }     
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().
                Property(p => p.Date).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            modelBuilder.Entity<Course>().
                Property(c => c.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            modelBuilder.Entity<Course>().
                Property(c => c.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Teacher>().
               Property(t => t.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Course>().
             Property(c => c.CreatedDate).HasColumnType("Date");

            modelBuilder.Entity<Subscriber>().
            Property(c => c.CreatedDate).HasColumnType("Date");

            modelBuilder.Entity<Subscriber>().
                Property(c => c.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            modelBuilder.Entity<Post>().
               Property(p => p.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Address>().
              Property(a => a.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<PostMessage>().
            Property(pm => pm.IsDeleted).HasDefaultValue(true);

            modelBuilder.Entity<PostMessage>().
            Property(pm => pm.IsReadable).HasDefaultValue(false);

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

            modelBuilder.Entity<Feature>(e => e.HasData(
new Feature
{
    Id = 1,
    Fee = 789,
    LessonTime = 3,
    Language = "English",
    Duration = 6,
    SkillLevel = "All",
    Assesments = "Self",
    StudentQuantity = 420
})
);
            modelBuilder.Entity<Course>(e => e.HasData(
new Course
{
    Id = 1,
    AboutCourse = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    Title = "CSS ENGINEERING",
    Text = "I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human happiness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui",
    HowToApply = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    FeatureId = 1,
    Certification = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    Image = "course1.jpg",
    CategoryId = 1
},
new Course
{
    Id = 2,
    AboutCourse = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    Title = "Micro Bology",
    Text = "I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human happiness pcias unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit asnatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui",
    HowToApply = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    FeatureId = 1,
    Certification = "I must explain to you how all this a mistaken idea of ncing great explorer of the rut the is lder of human happinescias unde omnis iste natus error sit volptatem accuntium mque laudantium perspiciatis unde omnis iste natuss",
    Image = "course1.jpg",
    CategoryId = 1
})
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
                   Image = "blog8.jpg",
                   CourseId = 1
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
                  Image = "blog2.jpg",
                  CourseId = 1
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
                  Image = "blog5.jpg",
                  CourseId = 1
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
                  Image = "blog7.jpg",
                  CourseId = 1

              }
               )
           );

            modelBuilder.Entity<Speaker>(e => e.HasData(
               new Speaker
               {
                   Id = 1,
                   Fullname = "Anthony Smith",
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
                  Image = "event1.jpg",
                  TimeIntervalId = 1,
                  Address = "Cristal Centre, 254 New Yourk",
                  CourseId = 1

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
                 Image = "event2.jpg",
                 TimeIntervalId = 2,
                 Address = "Cristal Centre, 254 New Yourk",
                 CourseId = 1
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
                 Image = "event3.jpg",
                 TimeIntervalId = 1,
                 Address = "Cristal Centre, 254 New Yourk",
                 CourseId = 1
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
                 Image = "event5.jpg",
                 TimeIntervalId = 2,
                 Address = "Cristal Centre, 254 New Yourk",
                 CourseId = 1

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

            modelBuilder.Entity<Footer>(e => e.HasData(
             new Footer
             {
                 Id = 1,
                 Address = "City, Roadno 785 New York",
                 Copyright = "<p>Copyright © <a href='#' target='_blank'>HasTech</a> 2017. All Right Reserved By Hastech.</p>",
                 Logo = "footer-logo.png",
                 Slogan = "I must explain to you how all this mistaken idea of denoung pleure and praising pain was born and give you a coete account of the system.",
                 website = "www.eduhome.com",
                 Facebook = "facebook.com",
                 Pinterest = "pinterest.com",
                 Twitter = "twitter.com",
                 Vimeo = "vimeo.com",
                 Email = "info@eduhome.com",
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
            modelBuilder.Entity<Teacher>(e => e.HasData(
             new Teacher
             {
                 Id = 1,
                AboutTeacher = "I must explain to you how all this a mistaken idea of denouncing great explorer of the rut the is lder of human happiness pcias unde omnis iste natus error sit voluptatem accusantium ue laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quas i architeo beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas",
                Faculty = "Din, Department of Micro Biology",
                Hobbies = "music, travelling, catching fish",
                Phone = "(+125) 5896 548 9874",
                Experience =7,
                Fullname = "STUART KELVIN",
                Professional = "Associate Professor",
                Communication = 95,
                Design = 95,
                Language = 85,
                TeamLeader = 90,
                Development = 85,
                Innovation = 85,
                 Email = " stuart@eduhome.com",
                 Skype = "stuart.k",
                 Facebook = "facebook.com",
                 Pinterest = "pinterest.com",
                 Twitter = "twitter.com",
                 Vimeo = "vimeo.com", 
                 Image = "teacher1.jpg"                 

             })
         );

            modelBuilder.Entity<About>(e => e.HasData(
            new About
            {
                Id = 1,
                Title = "<h2>WELCOME TO <span>EDUHOME</span></h2>",
                Text = "I must explain to you how all this mistaken idea of denouncing pleure and prsing pain was born and I will give you a complete account of the system, and expound the actual teachings  the master-builder of humanit happiness",
                Image = "about.png"
            })
        );

            modelBuilder.Entity<Contact>(e => e.HasData(
     new Contact
     {
         Id = 1
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
            modelBuilder.Entity<Address>(e => e.HasData(
          new Address
          {
              Id = 1,
              City = "New Yourk City",
              Street = "135, First Lane, City Street",
              Image = "contact1.png",
              ContactId = 1
          },
          new Address
          {
              Id = 2,
              City = "Philadelphia",
              Street = "135, First Lane, City Street",
              Image = "contact2.png",
              ContactId = 1
          })
      );

            modelBuilder.Entity<Subscribe>(e => e.HasData(
                        new Subscribe
                        {
                            Id = 1,
                            Title = "SUBSCRIBE OUR NEWSLETTER",
                            Text = "I must explain to you how all this mistaken idea"
                        })
                    );
        }
    }
}
