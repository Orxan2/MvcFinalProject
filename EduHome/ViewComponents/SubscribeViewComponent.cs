using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class SubscribeViewComponent: ViewComponent
    {
        public EduhomeDbContext _db;
        public SubscribeViewComponent(EduhomeDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SubscribeVM subscribeVM = new SubscribeVM
            {
                Subscribe = _db.Subscribes.FirstOrDefault()
            };
           
            return View(await Task.FromResult(subscribeVM));
        }
    }
}
