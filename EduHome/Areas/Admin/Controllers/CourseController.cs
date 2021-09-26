using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CourseController : Controller
    {
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public CourseController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Course> courses = _context.Courses.Include(c => c.Category).Include(c => c.Feature).Include(c => c.Events).
                 Include(c => c.Posts).Include(c => c.Teachers).Include(c => c.PostMessages).ToList();

            return View(courses);
        }

        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _context.Courses.Include(c => c.Category).Include(c => c.Feature).Include(c => c.Events).
                 Include(c => c.Posts).Include(c => c.Teachers).Include(c => c.PostMessages).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return BadRequest();
            }

            if (course.IsDeleted)
                course.IsDeleted = false;
            else
                course.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), course);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _context.Courses.Include(c => c.Category).Include(c => c.Feature).Include(c => c.Events).
                  Include(c => c.Posts).Include(c => c.Teachers).Include(c => c.PostMessages).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return BadRequest();
            }

            return View(course);
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
                Include(c => c.Events).Include(c => c.Feature).Include(c => c.Teachers).FirstOrDefault(c=>c.Id == id)
            };
            if (courseVM.Course == null)
            {
                return BadRequest();
            }

            return View(courseVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, CourseVM courseVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            //if user don't choose image program enter here
            if (courseVM.Course.Photo == null)
            {
                courseVM.Course.Image = courseVM.Image;

                ModelState["Course.Photo"].ValidationState = ModelValidationState.Valid;
                if (!ModelState.IsValid)
                {
                    return View(courseVM);
                }
                _context.Courses.Update(courseVM.Course);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), courseVM);
            }

            if (id != courseVM.Course.Id)
            {
                return NotFound();
            }

            if (!courseVM.Course.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (courseVM.Course.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            //removing old image from local folder
            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", "course", courseVM.Image);
            FileInfo oldFile = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                oldFile.Delete();
            };

            //coping new image in local folder
            string filename = Guid.NewGuid().ToString() + '-' + courseVM.Course.Photo.FileName;
            string newSlider = Path.Combine(environment, "img", "course", filename);
            using (FileStream newFile = new FileStream(newSlider, FileMode.Create))
            {
                courseVM.Course.Photo.CopyTo(newFile);
            }

            //new image and category initiliazing to Post class
            courseVM.Course.Image = filename;


            if (!ModelState.IsValid)
            {
                return View(courseVM.Course);
            }
            _context.Courses.Update(courseVM.Course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), courseVM);
        }

        public IActionResult Comments()
        {
            List<PostMessage> postMessages = _context.PostMessages.Include(pm => pm.Contact).Include(pm => pm.Course).Include(pm => pm.Post).
                Include(pm => pm.Event).Where(pm => pm.CourseId != null).ToList();

            return View(postMessages);
        }
        public IActionResult MakeDeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostMessage message = _context.PostMessages.Include(pm => pm.Contact).Include(pm => pm.Course).Include(pm => pm.Post).
               Include(pm => pm.Event).Where(pm => pm.CourseId != null).FirstOrDefault(pm => pm.Id == id);

            if (message == null)
            {
                return BadRequest();
            }

            if (message.IsDeleted == true)
                message.IsDeleted = false;
            else
                message.IsDeleted = true;


            _context.PostMessages.Update(message);
            _context.SaveChanges();

            return RedirectToAction(nameof(Comments));
        }
    }
}
