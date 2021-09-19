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
            int pag = 0; 
            if (ViewBag.Pagination != null && ViewBag.Pagination != 0)
            {
               pag = (ViewBag.Pagination-1) * quantity;
            }
            

            PostVM postVM = new PostVM
            {
                 Posts = _db.Posts.Include(c => c.Category).Skip(pag).Take(quantity).ToList()
            };

            return View(await Task.FromResult(postVM));
        }
    }

 
}
