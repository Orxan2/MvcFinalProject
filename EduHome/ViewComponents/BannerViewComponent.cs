using EduHome.DataContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public BannerViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View(await Task.FromResult("Default"));
        }
    }
}
