using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
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
    }
}
