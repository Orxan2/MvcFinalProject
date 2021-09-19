using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EduHome.Controllers
{
    public class PostController : Controller
    {
        private readonly EduhomeDbContext _db;
        public PostController(EduhomeDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index(int id)
        {

            ViewBag.Pagination = id;
            int count = Convert.ToInt32(Math.Ceiling(_db.Posts.Count() / 9.0));            
            return View(count);
        }

        public IActionResult PostDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _db.Posts.FirstOrDefault(b=>b.Id == id);

            if (post == null)
            {
                return BadRequest();
            }

            PostDetail postDeatailsVM = new PostDetail
            {
                Post = post,
                Categories = _db.Categories.ToList(),
                LatestPosts = _db.Posts.OrderByDescending(p=>p.Id).Take(3).ToList()
            };


            return View(postDeatailsVM);
        }
    }
}
