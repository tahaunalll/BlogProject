using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        //Proje düzeyine taşınan Authorization'dan kurtulmak için:
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new Context();
            //tek değer üzerinde sorgulama işlem için
            var value = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (value != null)
            {
                //using System.Security.Claims;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writer.WriterMail)
                };
                
                //2. parametre neden ? 
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                
                //using Microsoft.AspNetCore.Authentication;
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Index(Writer writer)
        //{
        //    //Daha sonra mimariye taşınacak
        //    Context context = new Context();
        //    //tek değer üzerinde sorgulama işlem için
        //    var value = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //    if (value!=null)
        //    {
        //        //using Microsoft.AspNetCore.Http;
        //        HttpContext.Session.SetString("username",writer.WriterMail);
        //        return RedirectToAction("Index", "Writer");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
