using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class PostCategoryVM
    {
        //public List<Post> Posts { get; set; }
        public List<Course> Courses { get; set; }
        public List<TimeInterval> TimeIntervals { get; set; }
        public Post Post { get; set; }
        public string Image { get; set; }

    }
}
