using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SubscriberController : Controller
    {
        public EduhomeDbContext _context { get; }
        public SubscriberController(EduhomeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {            
            List<Subscriber> subscribers = _context.Subscribers.ToList();          

            return View(subscribers);
        }

        public IActionResult MakeDeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Subscriber subscriber = _context.Subscribers.ToList().FirstOrDefault(pm => pm.Id == id);

            if (subscriber == null)
            {
                return BadRequest();
            }

            if (subscriber.IsDeleted == true)
                subscriber.IsDeleted = false;
            else
                subscriber.IsDeleted = true;


            _context.Subscribers.Update(subscriber);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
