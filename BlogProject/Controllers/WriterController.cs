using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        //Authorize attribute ü class düzeyine çıkartılabilir ihtiyaç durumuna göre
        //[Authorize] --> Proje ölçeğine taşındı Startup.cs içinde 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        //test amaçlı
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValues = writerManager.GetById(1);
            return View(writerValues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.TUpdate(writer);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfilePicture addProfilePicture)
        {
            Writer writer = new Writer();
            if (addProfilePicture.WriterImage!=null)
            {
                //using System.IO;
                var extension = Path.GetExtension(addProfilePicture.WriterImage.FileName);
                var newPicName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFile/", newPicName);
                var stream = new FileStream(location, FileMode.Create);
                addProfilePicture.WriterImage.CopyTo(stream);
                writer.WriterImage = newPicName;
            }
            writer.WriterAbout = addProfilePicture.WriterAbout;
            writer.WriterMail = addProfilePicture.WriterMail;
            writer.WriterName = addProfilePicture.WriterName;
            writer.WriterPassword = addProfilePicture.WriterPassword;
            writer.WriterStatus = addProfilePicture.WriterStatus;
            writerManager.TAdd(writer);
            return RedirectToAction("Index","DashBoard");
        }

    }

}
