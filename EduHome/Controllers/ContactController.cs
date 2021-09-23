using EduHome.DataContext;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
            
        private readonly EduhomeDbContext _db;
        public ContactController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ContactVM contact = new ContactVM
            {
                Contact = _db.Contact.Include(a => a.Addresses).Include(a => a.PostMessages).FirstOrDefault(),
                PostMessages = _db.PostMessages.Include(pm => pm.Contact).Include(pm => pm.Post).Include(pm => pm.Post).Where(pm => pm.ContactId != null).ToList(),
                PostMessage = _db.PostMessages.Include(pm => pm.Contact).Include(pm => pm.Post).Include(pm => pm.Post).FirstOrDefault(pm => pm.ContactId != null),
                Addresses = _db.Addresses.Include(a => a.Contact).ToList()
            };
            return View(contact);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(ContactVM contactVM)
        {
            contactVM.Addresses = _db.Addresses.Include(a => a.Contact).ToList();

            if (!ModelState.IsValid)
            {
                return View(contactVM);
            }
            contactVM.PostMessage.ContactId = 1;

            _db.PostMessages.Add(contactVM.PostMessage);
            _db.SaveChanges();

            return View(contactVM);
        }
    }
}
