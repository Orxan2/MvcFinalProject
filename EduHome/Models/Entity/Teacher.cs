using EduHome.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Teacher:BaseEntity
    {
        [Required,StringLength(maximumLength:75)]
        public string Fullname { get; set; }
        [Required, StringLength(maximumLength: 59)]
        public string Professional { get; set; }
        [Required]
        public string AboutTeacher { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Faculty { get; set; }
        [Required]
        public int Experience { get; set; }
        public string Hobbies { get; set; }
        [Required, StringLength(maximumLength: 25)]
        public string Phone { get; set; }
        [Required]
        public int Language { get; set; }
        [Required]
        public int Design { get; set; }
        [Required]
        public int Development { get; set; }
        [Required]
        public int TeamLeader { get; set; }
        [Required]
        public int Innovation { get; set; }
        [Required]
        public int Communication { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }        
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
        public string Skype { get; set; }
        public bool IsDeleted { get; set; }
        [BindNever]
        public string Image { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
        public Course Course { get; set; }
        public int? CourseId { get; set; }

    }
}
