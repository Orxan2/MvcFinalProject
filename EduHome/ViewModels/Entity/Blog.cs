using EduHome.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels.Entity
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Photo { get; set; }
        public string ByWhom { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        //public string Title { get; set; }
        //public string Title { get; set; }
    }
}
