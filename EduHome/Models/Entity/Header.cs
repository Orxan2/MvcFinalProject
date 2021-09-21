
using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Header : BaseEntity
    {
        public string Text { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
    }
}
