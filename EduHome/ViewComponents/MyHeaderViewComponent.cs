using EduHome.DataContext;
using EduHome.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class MyHeaderViewComponent : ViewComponent
    {
        public EduhomeDbContext _db;
        public MyHeaderViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Header header = _db.Header.FirstOrDefault();

            return View(await Task.FromResult(header));
        }
    }
}
