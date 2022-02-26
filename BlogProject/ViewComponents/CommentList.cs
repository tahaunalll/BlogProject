using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents
{
    //Component oluşturmak için ViewComponent Sınıfından miras alınacak..
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = new List<UserComment>
            {
                new UserComment
                {
                    UserCommentID=1,
                    Username="Taha"

                },
                new UserComment
                {
                    UserCommentID=2,
                    Username="Derin"
                },
                new UserComment
                {
                    UserCommentID=3,
                    Username="Egemen"
                }
            };
            return View(values);
        }
    }
}
