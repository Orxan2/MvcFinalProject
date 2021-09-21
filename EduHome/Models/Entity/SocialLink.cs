using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class SocialLink : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public Footer Footer { get; set; }
        public int FooterId { get; set; }

    }
}
