using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly EduhomeDbContext _db;
        public AboutViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            About about = _db.About.FirstOrDefault();

            return View(await Task.FromResult(about));
        }

    }
}
