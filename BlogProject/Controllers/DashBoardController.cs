using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class DashBoardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            //Daha sonra SOLID'e uygun düzenlenecek
            Context c = new Context();
            ViewBag.dashBlogsCount = c.Blogs.Count();
            ViewBag.dashcontBlogsCountByWriter = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.dashcontCategoriesCount = c.Categories.Count();
            return View();
        }
    }
}
