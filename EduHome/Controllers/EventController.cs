using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
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
            
            return View();
        }
    }
}
