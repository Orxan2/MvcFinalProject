using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{ 
    [Area("admin")]
    public class TeacherController : Controller
    {
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public TeacherController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Teacher> teachers = _context.Teachers.Include(c => c.Course).ThenInclude(c => c.Category).ToList();

            return View(teachers);
        }

        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _context.Teachers.Include(t => t.Course).ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return BadRequest();
            }

            if (teacher.IsDeleted)
                teacher.IsDeleted = false;
            else
                teacher.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), teacher);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _context.Teachers.Include(t => t.Course).ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return BadRequest();
            }

            return View(teacher);
        }

        public IActionResult Create()
        {
            CourseVM courseVM = new CourseVM
            {
                Categories = _context.Categories.Include(c => c.Courses).ToList()
            };
            return View(courseVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CourseVM courseVM)
        {
            if (!ModelState.IsValid)
            {
                return View(courseVM.Course);
            }
            if (!courseVM.Course.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (courseVM.Course.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            string filename = Guid.NewGuid().ToString() + '-' + courseVM.Course.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", "course", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                courseVM.Course.Photo.CopyTo(file);
            }
            courseVM.Course.Image = filename;

            _context.Courses.Add(courseVM.Course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), courseVM);
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseVM courseVM = new CourseVM
            {
                Categories = _context.Categories.Include(c => c.Courses).ToList(),
                Course = _context.Courses.Include(c => c.Category).Include(c => c.PostMessages).Include(c => c.Posts).
                Include(c => c.Events).Include(c => c.Feature).Include(c => c.Teachers).FirstOrDefault(c => c.Id == id)
            };
            if (courseVM.Course == null)
            {
                return BadRequest();
            }

            return View(courseVM);
        }
    }
}
