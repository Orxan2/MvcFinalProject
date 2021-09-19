using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class CourseTheme:BaseEntity
    {
        [Required,StringLength(maximumLength:50)]
        public string Title { get; set; }
        public string Text { get; set; }
        public List<CourseThemeCourse> CourseThemeCourses { get; set; }
    }
}
