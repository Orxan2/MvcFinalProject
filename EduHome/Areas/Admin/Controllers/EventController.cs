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

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EventController : Controller
    {
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public EventController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: EventController
        public IActionResult Index()
        {
            List<Event> @event = _context.Events.Include(e => e.Category).Include(e => e.TimeInterval).Include(e => e.PostMessages).
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).ToList();
            return View(@event);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event @event = _context.Events.Include(e => e.Category).Include(e => e.TimeInterval).Include(e => e.PostMessages).
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).Where(e => e.IsDeleted == false).FirstOrDefault(e => e.Id == id);

            if (@event == null)
            {
                return BadRequest();
            }

            return View(@event);
        }

        // GET: EventController/Create
        public IActionResult Create()
        {
            EventCategoryVM eventCategory = new EventCategoryVM
            {
                Categories = _context.Categories.ToList(),
                TimeIntervals = _context.TimeIntervals.ToList()
            };
            return View(eventCategory);
        }

        // POST: EventController/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(EventCategoryVM eventCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(eventCategory.Event);
            }
            if (!eventCategory.Event.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (eventCategory.Event.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }


            string filename = Guid.NewGuid().ToString() + '-' + eventCategory.Event.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", "event", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                eventCategory.Event.Photo.CopyTo(file);
            }
            eventCategory.Event.Image = filename;
            eventCategory.Event.Category = _context.Categories.FirstOrDefault(c=>c.Name == eventCategory.Category);
            eventCategory.Event.TimeInterval = _context.TimeIntervals.FirstOrDefault(t=>t.Name == eventCategory.TimeInterval);        

            _context.Events.Add(eventCategory.Event);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), eventCategory);
        }

        // GET: EventController/Edit/5
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventCategoryVM eventCategory = new EventCategoryVM
            {
                Event = _context.Events.Include(e => e.Category).Include(e => e.PostMessages).Where(e => e.IsDeleted == false).FirstOrDefault(e => e.Id == id),
                Categories = _context.Categories.ToList(),
                TimeIntervals = _context.TimeIntervals.ToList()
            };
            if (eventCategory.Event == null)
            {
                return BadRequest();
            }           

            return View(eventCategory);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, EventCategoryVM eventCategory)
        {
            if (id == null)
            {
                return NotFound();
            }

            //if user don't choose image program enter here
            if (eventCategory.Event.Photo == null)
            {
                eventCategory.Event.Category = _context.Categories.FirstOrDefault(c => c.Name == eventCategory.Category);
                eventCategory.Event.TimeInterval = _context.TimeIntervals.FirstOrDefault(t => t.Name == eventCategory.TimeInterval);
                eventCategory.Event.Image = eventCategory.Image;

                ModelState["Event.Photo"].ValidationState = ModelValidationState.Valid;
                if (!ModelState.IsValid)
                {
                    return View(eventCategory.Event);
                }
                _context.Events.Update(eventCategory.Event);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), eventCategory);
            }

            if (id != eventCategory.Event.Id)
            {
                return NotFound();
            }

            if (!eventCategory.Event.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (eventCategory.Event.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            //removing old image from local folder
            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", "event", eventCategory.Image);
            FileInfo oldFile = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                oldFile.Delete();
            };

            //coping new image in local folder
            string filename = Guid.NewGuid().ToString() + '-' + eventCategory.Event.Photo.FileName;
            string newSlider = Path.Combine(environment, "img", "event", filename);
            using (FileStream newFile = new FileStream(newSlider, FileMode.Create))
            {
                eventCategory.Event.Photo.CopyTo(newFile);
            }
            eventCategory.Event.Image = filename;
            eventCategory.Event.Category = _context.Categories.FirstOrDefault(c => c.Name == eventCategory.Category);


            if (!ModelState.IsValid)
            {
                return View(eventCategory.Event);
            }
            _context.Events.Update(eventCategory.Event);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), eventCategory);
        }

        // GET: EventController/Delete/5
        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event @event = _context.Events.Include(e => e.Category).Include(e=>e.TimeInterval).Include(e=>e.EventSpeakers).
                FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return BadRequest();
            }

            if (@event.IsDeleted)
                @event.IsDeleted = false;
            else
                @event.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
      
        
    }
}
