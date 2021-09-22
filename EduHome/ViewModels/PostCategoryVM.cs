using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class PostCategoryVM
    {

        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public string Category { get; set; }
        public Post Post { get; set; }
        public string Image { get; set; }
    }
}
