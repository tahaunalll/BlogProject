using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.EntityFramework;

namespace BlogProject.ViewComponents.Category
{
    public class CategoryListDashBoard:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
