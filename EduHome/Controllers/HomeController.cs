using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly EduhomeDbContext _db;
        public HomeController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            CourseSearchingVM course = new CourseSearchingVM
            {
                quantity = 3
            };
            return View(course);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Subscribe(SubscribeVM subscribeVM)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            List<Subscriber> subscribers = _db.Subscribers.ToList();
            if (subscribers.Exists(s=>s.Email == subscribeVM.Subscriber.Email))
            {
                return NotFound();
            }

            _db.Subscribers.Add(subscribeVM.Subscriber);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
