using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Phone : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public Footer Footer { get; set; }
        public int FooterId { get; set; }
    }
}
