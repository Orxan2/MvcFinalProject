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
    public class About : BaseEntity
    {
        [Required,StringLength(maximumLength:50)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [BindNever]
        public string Image { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
    }
}
