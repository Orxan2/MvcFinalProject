using EduHome.DataContext;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class MyBlogViewComponent:ViewComponent
    {
        public EduhomeDbContext _db;
        public MyBlogViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int quantity)
        {
             BlogVM blogVM = new BlogVM
            {
                 Blogs = _db.Blogs.Include(c => c.Category).Take(quantity).ToList()
            };

            return View(await Task.FromResult(blogVM));
        }
    }

 
}
