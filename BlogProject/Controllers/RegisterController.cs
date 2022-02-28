using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        //Attribute ataması
        // /register/index --> sayfa yüklenme anı
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        // /register/index --> tetikleme işlemi esnası
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            //using FluentValidation.Results; olacak Data Anotations degil
            ValidationResult results = wv.Validate(writer);
            if(results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "test";
                wm.TAdd(writer);
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            //Index Action, Blog Controller
            //return RedirectToAction("Index","Blog");

            return View();
        }
    }
}
