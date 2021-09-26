using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class TeacherVM
    {
        public List<Course> Courses { get; set; }
        public Teacher Teacher { get; set; }
        public string Image { get; set; }
    }
}
