using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly EduhomeDbContext _db;
        public CoursesController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Course> courses = _db.Courses.Include(c => c.Category).Include(c => c.Posts).Include(c => c.Events).Include(c => c.Feature).ToList();

            return View(courses);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _db.Courses.Include(c => c.Category).Include(c => c.Posts).Include(c => c.Events).Include(p => p.Feature).
                Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (course == null)
            {
                return BadRequest();
            }

            return View(course);
        }
    }
}
