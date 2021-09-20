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
    public class Speaker:BaseEntity
    {
        [Required,StringLength(maximumLength:100)]
        public string Fullname { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Professional { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
