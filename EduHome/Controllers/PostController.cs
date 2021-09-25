
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
           
            PostDetailVM postDetailVM = new PostDetailVM
            {
                Post = post,
                PostMessages = _db.PostMessages.Include(pm => pm.Course).Include(pm => pm.Event)
               .Include(pm => pm.Post).Include(pm => pm.Contact).Where(pm => pm.IsDeleted == false && pm.PostId == id).ToList()
            };

            return View(postDetailVM);
        }

        

        public IActionResult MessageLoad(int? id,string name, string email, string subject, string message)
        {
            if (id == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) ||
                string.IsNullOrEmpty(message))
            {
                return View();
            }

            PostMessage comment = new PostMessage
            {
                Name = name,
                Email = email,
                Message = message,
                Subject = subject
            };
            comment.PostId = id;
            _db.PostMessages.Add(comment);
            _db.SaveChanges();
            
            return PartialView("_MessageLoad", comment);
        }
    }
}
