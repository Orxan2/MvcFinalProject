using EduHome.DataContext;
using EduHome.Models.Entity;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace EduHome.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        public EduhomeDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public ContactController(EduhomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Address> adresses = _context.Addresses.Include(a => a.Contact).ToList();

            return View(adresses);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address address = _context.Addresses.Include(a => a.Contact).FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                return BadRequest();
            }

            return View(address);
        }
        public IActionResult DeleteOrActive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address address = _context.Addresses.Include(a=>a.Contact).FirstOrDefault(a => a.Id == id);
            if (address == null)
            {
                return BadRequest();
            }

            if (address.IsDeleted)
                address.IsDeleted = false;
            else
                address.IsDeleted = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), address);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactVM contactVM = new ContactVM
            {
                Address = _context.Addresses.Include(a => a.Contact).FirstOrDefault(a => a.Id == id)
            };

            if (contactVM.Address == null)
            {
                return BadRequest();
            }

            return View(contactVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, ContactVM contactVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            //if user don't choose image program enter here
            if (contactVM.Address.Photo == null)
            {

                contactVM.Address.Image = contactVM.Image;

                ModelState["Address.Photo"].ValidationState = ModelValidationState.Valid;
                if (!ModelState.IsValid)
                {
                    return View(contactVM);
                }
                _context.Addresses.Update(contactVM.Address);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), contactVM);
            }

            if (id != contactVM.Address.Id)
            {
                return NotFound();
            }

            if (!contactVM.Address.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (contactVM.Address.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }

            //removing old image from local folder
            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", "contact", contactVM.Image);
            FileInfo oldFile = new FileInfo(folderPath);
            if (System.IO.File.Exists(folderPath))
            {
                oldFile.Delete();
            };

            //coping new image in local folder
            string filename = Guid.NewGuid().ToString() + '-' + contactVM.Address.Photo.FileName;
            string newSlider = Path.Combine(environment, "img", "contact", filename);
            using (FileStream newFile = new FileStream(newSlider, FileMode.Create))
            {
                contactVM.Address.Photo.CopyTo(newFile);
            }

            //new image and category initiliazing to Post class
            contactVM.Address.Image = filename;


            if (!ModelState.IsValid)
            {
                return View(contactVM);
            }
            _context.Addresses.Update(contactVM.Address);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), contactVM);
        }
    }
}
