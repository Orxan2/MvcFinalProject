using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseVM
    {
        public List<Teacher> Teachers { get; set; }
        public List<Category> Categories { get; set; }
        public List<TimeInterval> TimeIntervals { get; set; }
        public Course Course { get; set; }
        public string Image { get; set; }
    }
}
