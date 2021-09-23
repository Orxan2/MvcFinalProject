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
    public class LatestPostsViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public LatestPostsViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            PostDetailVM postDetail = new PostDetailVM
            {
                LatestPosts = _db.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Take(3).ToList(),
                Categories = _db.Categories.ToList()
            };

            return View(await Task.FromResult(postDetail));
        }
    }
}
