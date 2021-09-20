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
    public class Event : BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string ByWhom { get; set; }
        public string Address { get; set; }
        [DataType(dataType: DataType.Text)]
        public string Details { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public int? TimeIntervalId { get; set; }
        public List<PostMessage> PostMessages { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
