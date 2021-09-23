using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class EventCategoryVM
    {
        //public List<Event> Events { get; set; }
        public List<Course> Courses { get; set; }
        public int CourseId { get; set; }
        public int TimeIntervalId { get; set; }
        public List<TimeInterval> TimeIntervals { get; set; }
        public Event Event { get; set; }
        public string Image { get; set; }
    }
}
