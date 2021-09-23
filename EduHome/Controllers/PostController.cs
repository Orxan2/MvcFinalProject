
using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            int count = Convert.ToInt32(Math.Ceiling(_db.Posts.Include(p => p.PostMessages).Include(p => p.Course).ThenInclude(c => c.Category).
                Count(p => p.IsDeleted == false) / 9.0));
            return View(count);
        }

        public IActionResult PostDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _db.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (post == null)
            {
                return BadRequest();
            }

            PostDetailVM postDetailsVM = new PostDetailVM
            {
                Post = post,
                Categories = _db.Categories.Include(c => c.Courses).ThenInclude(c => c.Category).ToList(),
                LatestPosts = _db.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).Take(3).ToList(),
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Post).Where(pm => pm.PostId == id).ToList()
            };

            return View(postDetailsVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult PostDetail(int? id, PostMessage postMessage)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _db.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).
                Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (post == null)
            {
                return BadRequest();
            }
            if (post.Id != id)
            {
                return BadRequest();
            }
            postMessage.PostId = id;
            PostDetailVM postDetailsVM = new PostDetailVM
            {
                Post = post,
                Categories = _db.Categories.Include(c => c.Courses).ThenInclude(c => c.Category).ToList(),
                LatestPosts = _db.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).
                Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).Take(3).ToList(),
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Post).Where(pm => pm.PostId == id).ToList(),
                PostMessage = postMessage
            };

            if (!ModelState.IsValid)
            {
                return View(postDetailsVM);
            }

            postDetailsVM.PostMessages.Add(postMessage);
            _db.Add(postMessage);
            _db.SaveChanges();


            return View(postDetailsVM);
        }
    }
}
