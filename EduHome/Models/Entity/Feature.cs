using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Feature : BaseEntity
    {
        [Required,StringLength(maximumLength:25)]
        public string SkillLevel { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int LessonTime { get; set; }
        [Required,StringLength(maximumLength:10)]
        public string Language { get; set; }
        [Required,StringLength(maximumLength:25)]
        public string Assesments { get; set; }
        [Required]
        public int StudentQuantity { get; set; }
        [Required]
        public double Fee { get; set; }
        public List<Course> Courses { get; set; }

    }
}
