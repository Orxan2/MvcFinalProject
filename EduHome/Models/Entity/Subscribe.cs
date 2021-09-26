using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Subscribe:BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
