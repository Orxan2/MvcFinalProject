using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EventController : Controller
    {
        public EduhomeDbContext _context { get; }
        public EventController(EduhomeDbContext context)
        {
            _context = context;
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
                Include(e => e.EventSpeakers).ThenInclude(es=>es.Speaker).Where(e => e.IsDeleted == false).FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return BadRequest();
            }

            return View(@event);            
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
