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
    public class Course:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [BindNever]
        public string Image { get; set; }
        public string HowToApply { get; set; }
        public string AboutCourse { get; set; }
        public string Certification { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public Feature Feature { get; set; }
        public int FeatureId { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public List<Post> Posts { get; set; }
        public List<Event> Events { get; set; }
        public List<Teacher> Teachers { get; set; }

    }
}
