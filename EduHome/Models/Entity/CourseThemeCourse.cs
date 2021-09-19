using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class CourseThemeCourse:BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CourseThemeId { get; set; }
        public CourseTheme CourseTheme { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
