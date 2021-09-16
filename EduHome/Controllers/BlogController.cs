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
    public class BlogController : Controller
    {
        private readonly EduhomeDbContext _db;
        public BlogController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog blog = _db.Blogs.FirstOrDefault(b=>b.Id == id);

            if (blog == null)
            {
                return BadRequest();
            }

            BlogDetailsVM blogDeatailsVM = new BlogDetailsVM
            {
                Blog = blog,
                Categories = _db..ToList<BlogDetailsVM>()
            };


            return View(blogDeatailsVM);
        }
    }
}
