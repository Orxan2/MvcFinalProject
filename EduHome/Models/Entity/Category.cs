using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Category:BaseEntity
    {
        [Required, StringLength(maximumLength: 50)]
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public List<Event> Events { get; set; }
        public List<CourseThemeCourse> CourseThemeCourses { get; set; }
    }
}
