using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        public EduhomeDbContext _context { get; }
        public DashboardController(EduhomeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var posts = _context.Posts.Include(p => p.Category).Include(p => p.PostMessages).ToList();
            PostVM postVM = new PostVM
            {
                Posts = _context.Posts.Include(p => p.Category).ToList()
            };
            return View(postVM);
        }
                
        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _context.Posts.Include(p=>p.Category).FirstOrDefault(p=>p.Id == id);
            if (post == null)
            {
                return BadRequest();
            }

            if (post.IsDeleted)
                post.IsDeleted = false;
            else
                post.IsDeleted = true;

            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index),post);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _context.Posts.Include(p => p.Category).Include(p=>p.PostMessages).Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return BadRequest();
            }

            return View(post);
        }
    }
}
