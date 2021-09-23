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
    public class EventController : Controller
    {
        private readonly EduhomeDbContext _db;
        public EventController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var events = _db.Events.Include(e => e.Course).ThenInclude(c => c.Category).Include(e=>e.TimeInterval).Include(e => e.PostMessages).
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).Where(e => e.IsDeleted == false).ToList();

            return View(events);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event @event = _db.Events.Include(p => p.Course).ThenInclude(c => c.Category).Include(e => e.TimeInterval).Include(e => e.PostMessages).
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (@event == null)
            {
                return BadRequest();
            }

            EventDetailVM eventDetailVM = new EventDetailVM
            {
                Event = @event,
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Post).Where(pm => pm.EventId == id).ToList()
            };

            return View(eventDetailVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Detail(int? id, PostMessage postMessage)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event @event = _db.Events.Include(p => p.Course).ThenInclude(c => c.Category).Include(e => e.PostMessages).Include(e=>e.TimeInterval).
                Include(e => e.EventSpeakers).ThenInclude(es => es.Speaker).Where(p => p.IsDeleted == false).FirstOrDefault(b => b.Id == id);

            if (@event == null)
            {
                return BadRequest();
            }
            if (@event.Id != id)
            {
                return BadRequest();
            }
            postMessage.EventId = @event.Id;
            EventDetailVM eventDetailVM = new EventDetailVM
            {
                Event = @event,
                PostMessages = _db.PostMessages.Include(pm => pm.Event).Include(pm => pm.Contact).Include(pm => pm.Course).Include(pm => pm.Post).
                Where(pm => pm.EventId == id && pm.IsDeleted == false).ToList(),
                PostMessage = postMessage                
            };

            if (!ModelState.IsValid)
            {
                return View(eventDetailVM);
            }

            eventDetailVM.PostMessages.Add(postMessage);
            _db.Add(postMessage);
            _db.SaveChanges();

            return View(eventDetailVM);
        }
    }
}
