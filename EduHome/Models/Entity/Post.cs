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
    public class Post:BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [BindNever]
        public string Image { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string ByWhom { get; set; }       
        public Nullable<DateTime> Date { get; set; }
        [DataType(dataType:DataType.Text)]
        public string Details { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public List<PostMessage> PostMessages { get; set; }

    }
}
