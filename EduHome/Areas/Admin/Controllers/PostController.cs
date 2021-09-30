using EduHome.DataContext;
using EduHome.Helpers.Methods;
using EduHome.Models.Base;
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
    public class PostController : Controller
    {       
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public PostController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            PostVM postVM = new PostVM
            {
                Posts = _context.Posts.Include(p => p.Course).ThenInclude(p => p.Category).Include(p => p.PostMessages).ToList()
            };
            return View(postVM);
        }
        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _context.Posts.Include(p => p.Course).ThenInclude(p => p.Category).Include(p => p.PostMessages).FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return BadRequest();
            }

            if (post.IsDeleted)
                post.IsDeleted = false;
            else
                post.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), post);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = _context.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).
                Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return BadRequest();
            }

            return View(post);
        }
        public IActionResult Create()
        {
            PostCategoryVM postCategory = new PostCategoryVM
            {
                Courses = _context.Courses.Include(c => c.Category).
                Include(c => c.Feature).Include(c=>c.Posts).Include(c=>c.Events).ToList()
            };
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

            _context.Posts.Add(postCategory.Post);
            _context.SaveChanges();

            List<Subscriber> subscribers = _context.Subscribers.ToList();

            foreach (var subscriber in subscribers.Where(s=>s.IsDeleted == false))
            {
                BaseMessage message = new BaseMessage();
                message.Email = subscriber.Email;
                message.Subject = "A post created";
                message.Message = "We created a post.You can see if you want";

                MailOperations.SendMessage(message);
               
            }


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
                Courses = _context.Courses.Include(c => c.Category).Include(c => c.Feature).Include(c => c.Events).
                Include(c => c.Posts).ToList(),
                Post = _context.Posts.Include(p => p.Course).ThenInclude(c => c.Category).Include(p => p.PostMessages).
                Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id),
            };
            if (postCategory.Post == null)
            {
                return BadRequest();
            }

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

            //if user don't choose image program enter here
            if (postCategory.Post.Photo == null)
            {
                postCategory.Post.Image = postCategory.Image;

                ModelState["Post.Photo"].ValidationState = ModelValidationState.Valid;
                if (!ModelState.IsValid)
                {
                    return View(postCategory);
                }
                _context.Posts.Update(postCategory.Post);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), postCategory);
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

            //removing old image from local folder
            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", "blog", postCategory.Image);
            FileInfo oldFile = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                oldFile.Delete();
            };

            //coping new image in local folder
            string filename = Guid.NewGuid().ToString() + '-' + postCategory.Post.Photo.FileName;
            string newSlider = Path.Combine(environment, "img", "blog", filename);
            using (FileStream newFile = new FileStream(newSlider, FileMode.Create))
            {
                postCategory.Post.Photo.CopyTo(newFile);
            }

            //new image and category initiliazing to Post class
            postCategory.Post.Image = filename;


            if (!ModelState.IsValid)
            {
                return View(postCategory.Post);
            }
            _context.Posts.Update(postCategory.Post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), postCategory);
        }


        public IActionResult Comments()
        {
            List<PostMessage> postMessages = _context.PostMessages.Include(pm => pm.Contact).Include(pm=>pm.Course).Include(pm => pm.Post).
                Include(pm => pm.Event).Where(pm => pm.PostId != null).ToList();

            return View(postMessages);
        }
        public IActionResult MakeDeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostMessage message = _context.PostMessages.Include(pm => pm.Contact).Include(pm => pm.Course).Include(pm => pm.Post).
               Include(pm => pm.Event).Where(pm => pm.PostId != null).FirstOrDefault(pm => pm.Id == id);

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
