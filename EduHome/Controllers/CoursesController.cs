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

            CourseDetailVM courseDetailVM = new CourseDetailVM
            {
                Course = _db.Courses.Include(c => c.Category).Include(c => c.Posts).Include(c => c.Events).Include(p => p.Feature).
                Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id),
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Course).Include(pm => pm.Post).Where(pm => pm.CourseId == id).ToList(),
                //PostMessage = postMessage
            };

            if (courseDetailVM.Course == null)
            {
                return BadRequest();
            }

            return View(courseDetailVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Details(int? id, PostMessage postMessage)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _db.Courses.Include(c => c.Feature).Include(c => c.Category).Include(c => c.Posts).Include(p => p.Events).
                Include(c => c.PostMessages).Where(c => c.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (course == null)
            {
                return BadRequest();
            }
            if (course.Id != id)
            {
                return BadRequest();
            }
            postMessage.CourseId = id;
            CourseDetailVM courseDetailVM = new CourseDetailVM
            {
                Course = course,
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Contact).Include(pm => pm.Course).Include(pm => pm.Post).
                Where(pm => pm.CourseId == id && pm.IsDeleted == false).ToList(),
                PostMessage = postMessage
            };

            if (!ModelState.IsValid)
            {
                return View(courseDetailVM);
            }

            courseDetailVM.PostMessages.Add(postMessage);
            _db.Add(postMessage);
            _db.SaveChanges();

            return View(courseDetailVM);
        }
    }
}