using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.ADO;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        #region Listing Pages

        [AllowAnonymous]
        public IActionResult Index()
        {
            //var values = blogManager.GetList();
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }


        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i=id;
            var values = blogManager.GetBlogListByBlogID(id);
            return View(values);
        }
        
        public IActionResult BlogListByWriter()
        {
            //var values = blogManager.GetBlogListByWriterID(1);
            var values = this.GetBlogListWithCategoryByWriterID(1);
            return View(values);
        }
        #endregion
        #region BlogAdd
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            //using Microsoft.AspNetCore.Mvc.Rendering;

            //dropdown için text --> kullanıcı value --> db
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();

            //using FluentValidation.Results;
            ValidationResult validationResult = bv.Validate(blog);

            if (validationResult.IsValid)
            {
                //statik veri atamaları
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                blogManager.TAdd(blog);
            }
            return RedirectToAction("BlogListByWriter","Blog");
        }
        #endregion
        #region GetBlogListWithCategoryByWriterID : return List<Blog>
        public List<Blog> GetBlogListWithCategoryByWriterID (int id)
        {
            return blogManager.GetBlogListWithCategoryByWriterID(id);
        }
        #endregion   
        #region Delete Blog
        public IActionResult DeleteBlog(int id)
        {
            //ilk başta silinecek olan nesneyi seçiyoruz.
            var blogValue = blogManager.GetById(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter","Blog");
        }
        #endregion

        #region EditBlog
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var blogValue = blogManager.GetById(id);

            //SelectListItem oluşturma
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            //ViewBag önemli ! view-controller baglama
            ViewBag.t = categoryValues;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //hatadan çıkmak için statik veri ataması
            blog.WriterID = 1;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        #endregion

    }
}
