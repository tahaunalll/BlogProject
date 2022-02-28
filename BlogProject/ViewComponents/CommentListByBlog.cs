using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents
{
    public class CommentListByBlog: ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        //id değerini almak için @viewbag kullandık --> ~/Views/Blog/BlogReadAll.cshtml
        //id parametresine verinin nasıl atandığına dikkat et
        public IViewComponentResult Invoke(int id)
        {
            
            var values = cm.GetCommentByBlogID(id);
            return View(values);
        }
    }
}
