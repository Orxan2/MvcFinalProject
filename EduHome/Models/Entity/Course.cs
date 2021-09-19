using EduHome.Models.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Course:BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        public string Text { get; set; }
        public List<CourseThemeCourse> CourseThemeCourses { get; set; }    
        
    }
}
