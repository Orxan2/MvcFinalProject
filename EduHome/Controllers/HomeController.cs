using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CourseSearchingVM course = new CourseSearchingVM
            {
                quantity = 3
            };
            return View(course);
        }
    }
}
