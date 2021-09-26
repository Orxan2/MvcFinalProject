using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TeacherViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public TeacherViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int quantity = 4)
        {
            List<Teacher> teachers = _db.Teachers.Include(t => t.Course).ThenInclude(c=>c.Category).Where(t=>t.IsDeleted == false).
                OrderByDescending(c => c.Id).Take(quantity).ToList();

            return View(await Task.FromResult(teachers));
        }
    }
}
