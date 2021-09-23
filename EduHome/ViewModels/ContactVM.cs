using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class ContactVM
    {
        public Contact Contact { get; set; }
        public List<PostMessage> PostMessages { get; set; }
        public PostMessage PostMessage { get; set; }
        public List<Address> Addresses { get; set; }
        public Address Address { get; set; }
        public string Image { get; set; }
    }
}
