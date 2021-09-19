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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().
                Property(p => p.Date).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

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
                   ByWhom= "Orxan",
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
        }
    }
}
