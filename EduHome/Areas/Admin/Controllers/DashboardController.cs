using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            PostCategoryVM postCategory = new PostCategoryVM { Categories = _context.Categories.ToList() };
            return View(postCategory);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PostCategoryVM postCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(postCategory.Post);
            }
            if (!postCategory.Post.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (postCategory.Post.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }


            string filename = Guid.NewGuid().ToString() + '-' + postCategory.Post.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", "blog", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                postCategory.Post.Photo.CopyTo(file);
            }
            postCategory.Post.Image = filename;            
            postCategory.Post.Category = new Category
            {
                Name = postCategory.Category
            };

          
            _context.Posts.Add(postCategory.Post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), postCategory);
            
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostCategoryVM postCategory = new PostCategoryVM
            {
                Post = _context.Posts.Include(p => p.Category).Include(p => p.PostMessages).Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id),
                Categories = _context.Categories.ToList()                
            };
            if (postCategory.Post == null)
            {
                return BadRequest();
            }

            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img","blog", postCategory.Post.Image);
            FileInfo file = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                file.Delete();
            };
           

            return View(postCategory);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, PostCategoryVM postCategory)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != postCategory.Post.Id)
            {
                return NotFound();
            }

            if (!postCategory.Post.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (postCategory.Post.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }


            string filename = Guid.NewGuid().ToString() + '-' + postCategory.Post.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", "blog", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {               
                postCategory.Post.Photo.CopyTo(file);
            }
            postCategory.Post.Image = filename;
            postCategory.Post.Category = new Category
            {
                Name = postCategory.Category
            };

            if (!ModelState.IsValid)
            {
                return View(postCategory.Post);
            }
            _context.Posts.Update(postCategory.Post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), postCategory);
        }
    }
}
