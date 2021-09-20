using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class EventSpeaker:BaseEntity
    {
        public Event Event { get; set; }
        public int? EventId { get; set; }
        public Speaker Speaker { get; set; }
        public int? SpeakerId { get; set; }
    }
}
