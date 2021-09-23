using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseDetailVM
    {
        public Course Course { get; set; }
        public List<PostMessage> PostMessages { get; set; }
        public PostMessage PostMessage { get; set; }
    }
}
