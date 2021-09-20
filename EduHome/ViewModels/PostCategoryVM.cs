﻿using EduHome.Models.Entity;
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
    }
}