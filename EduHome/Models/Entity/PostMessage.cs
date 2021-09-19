using EduHome.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class PostMessage
    {
        public int? Id { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [Required, StringLength(maximumLength: 25)]
        public string Subject { get; set; }
        public Post Post { get; set; }
        public int? PostId { get; set; }
       
    }
}
