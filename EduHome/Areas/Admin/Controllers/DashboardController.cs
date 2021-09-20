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
    public class DashboardController : Controller
    {
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public DashboardController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
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

        public IActionResult Create()
        {
            PostCategoryVM model= new PostCategoryVM { Categories = _context.Categories.ToList() };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PostCategoryVM postCategory)
        {


            //if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            //{
            //    return NotFound();
            //};
            //if (!post.Photo.ContentType.Contains("image"))
            //{
            //    return NotFound();
            //}
            //if (post.Photo.Length / 1024 > 3000)
            //{
            //    return NotFound();
            //}


            //string filename = Guid.NewGuid().ToString() + '-' + post.Photo.FileName;
            //string environment = _env.WebRootPath;
            //string newSlider = Path.Combine(environment, "img","blog", filename);
            //using (FileStream file = new FileStream(newSlider, FileMode.Create))
            //{
            //    post.Photo.CopyTo(file);
            //}
            //post.Image = filename;

            //if (!ModelState.IsValid)
            //{
            //    return View(post);
            //}
            //_context.Posts.Add(post);
            //_context.SaveChanges();



            //return RedirectToAction(nameof(Index));

            return Content(postCategory.Category);
        }
    }
}
