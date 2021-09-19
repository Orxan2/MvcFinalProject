using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            Post post = _db.Posts.Include(p => p.Category).FirstOrDefault(b => b.Id == id);

            if (post == null)
            {
                return BadRequest();
            }

            PostDetailVM postDetailsVM = new PostDetailVM
            {
                Post = post,
                Categories = _db.Categories.ToList(),
                LatestPosts = _db.Posts.OrderByDescending(p => p.Id).Take(3).ToList(),
                PostMessages = _db.PostMessages.Include(pm=>pm.Post).Where(pm=>pm.PostId == id).ToList()
            };

            return View(postDetailsVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult PostDetail(int? id,PostMessage postMessage)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _db.Posts.Include(p => p.Category).FirstOrDefault(b => b.Id == id);

            if (post == null)
            {
                return BadRequest();
            }
            postMessage.PostId = id;
            PostDetailVM postDetailsVM = new PostDetailVM
            {
                Post = post,
                Categories = _db.Categories.ToList(),
                LatestPosts = _db.Posts.Include(p => p.Category).OrderByDescending(p => p.Id).Take(3).ToList(),
                PostMessages = _db.PostMessages.Include(pm => pm.Post).Where(pm => pm.PostId == id).ToList(),
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
