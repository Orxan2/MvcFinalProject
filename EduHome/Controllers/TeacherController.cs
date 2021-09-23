using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly EduhomeDbContext _db;
        public TeacherController(EduhomeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int count = 12;
            return View(count);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _db.Teachers.Include(t => t.Course).ThenInclude(c => c.Category).Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return BadRequest();
            }            

            return View(teacher);
        }
    }
}
