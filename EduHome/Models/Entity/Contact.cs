using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Contact:BaseEntity
    {
        public List<PostMessage> PostMessages { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
