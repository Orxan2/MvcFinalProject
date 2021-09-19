using EduHome.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class PostDetail
    {
        public Post Post { get; set; }
        public List<Category> Categories { get; set; }       
        public List<Post> LatestPosts { get; set; }
    }
}
