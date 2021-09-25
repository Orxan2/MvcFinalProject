using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public CourseViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(CourseSearchingVM courseSearching)
        {
            List<Course> courses = _db.Courses.Include(c => c.Feature).Include(c => c.Category).Include(c => c.Posts).Include(c => c.Events).
                Where(c=>c.IsDeleted == false).Take(courseSearching.quantity).OrderByDescending(c => c.Id).ToList();

            if (courseSearching.courseTitle!= null)
            {
                courses = courses.Where(c => c.Title.Contains(courseSearching.courseTitle)).ToList();
            }        
            return View(await Task.FromResult(courses));
        }
    }
}
