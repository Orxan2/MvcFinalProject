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
            TeacherVM teacherVM = new TeacherVM
            {
                Courses = _context.Courses.Include(c => c.Category).Include(c => c.Feature).Include(c => c.Events).
                 Include(c => c.Posts).Include(c => c.Teachers).Include(c => c.PostMessages).ToList()
        };
            return View(teacherVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(TeacherVM teacherVM)
        {
            if (!ModelState.IsValid)
            {
                return View(teacherVM.Teacher);
            }
            if (!teacherVM.Teacher.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (teacherVM.Teacher.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            string filename = Guid.NewGuid().ToString() + '-' + teacherVM.Teacher.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", "teacher", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                teacherVM.Teacher.Photo.CopyTo(file);
            }
            teacherVM.Teacher.Image = filename;

            _context.Teachers.Add(teacherVM.Teacher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), teacherVM);
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeacherVM teacherVM = new TeacherVM
            {
                Courses = _context.Courses.Include(c => c.Category).Include(c => c.PostMessages).Include(c => c.Posts).
                Include(c => c.Events).Include(c => c.Feature).Include(c => c.Teachers).ToList(),
                Teacher = _context.Teachers.Include(t => t.Course).ThenInclude(c => c.Category).FirstOrDefault(t=>t.Id ==  id)
            };
            if (teacherVM.Teacher == null)
            {
                return BadRequest();
            }

            return View(teacherVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, TeacherVM teacherVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            //if user don't choose image program enter here
            if (teacherVM.Teacher.Photo == null)
            {
                teacherVM.Teacher.Image = teacherVM.Image;

                ModelState["Teacher.Photo"].ValidationState = ModelValidationState.Valid;
                if (!ModelState.IsValid)
                {
                    return View(teacherVM);
                }
                _context.Teachers.Update(teacherVM.Teacher);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), teacherVM);
            }

            if (id != teacherVM.Teacher.Id)
            {
                return NotFound();
            }

            if (!teacherVM.Teacher.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (teacherVM.Teacher.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            //removing old image from local folder
            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", "teacher", teacherVM.Image);
            FileInfo oldFile = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                oldFile.Delete();
            };

            //coping new image in local folder
            string filename = Guid.NewGuid().ToString() + '-' + teacherVM.Teacher.Photo.FileName;
            string newSlider = Path.Combine(environment, "img", "teacher", filename);
            using (FileStream newFile = new FileStream(newSlider, FileMode.Create))
            {
                teacherVM.Teacher.Photo.CopyTo(newFile);
            }

            //new image and category initiliazing to Post class
            teacherVM.Teacher.Image = filename;


            if (!ModelState.IsValid)
            {
                return View(teacherVM.Teacher);
            }
            _context.Teachers.Update(teacherVM.Teacher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), teacherVM);
        }
    }
}
