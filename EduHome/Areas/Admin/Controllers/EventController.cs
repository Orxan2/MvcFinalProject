using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).Where(e => e.IsDeleted == false).ToList();
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
            //eventCategory.Event.TimeInterval.Name = eventCategory.TimeInterval;

            //eventCategory.Event.Category = new Category
            //{
            //    Name = eventCategory.Category
            //};
            //eventCategory.Event.TimeInterval = new TimeInterval
            //{
            //    Name = eventCategory.TimeInterval
            //};

            _context.Events.Add(eventCategory.Event);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), eventCategory);

        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
