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
    public class MyFooterViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public MyFooterViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Footer footer = _db.Footer.Include(f => f.Phones).Include(f => f.SocialLinks).FirstOrDefault();

            return View(await Task.FromResult(footer));
        }
    }
}
