using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class PostMessage:BaseMessage
    {               
        public Post Post { get; set; }
        public int? PostId { get; set; }
        public Event Event { get; set; }
        public int? EventId { get; set; }
        public Course Course { get; set; }
        public int? CourseId { get; set; }
        public Contact Contact { get; set; }
        public int? ContactId { get; set; }
    }
}
