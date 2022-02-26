using BusinessLayer.Concrete;
using DataAccessLayer.ADO;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        //BlogManager blogManager = new BlogManager(new ADOBlogRepository());
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            //var values = blogManager.GetList();
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }


        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }
    }
}
