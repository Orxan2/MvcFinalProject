using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class Footer : BaseEntity
    {
        public string Logo { get; set; }
        public string Slogan { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string website { get; set; }
        public string Copyright { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
