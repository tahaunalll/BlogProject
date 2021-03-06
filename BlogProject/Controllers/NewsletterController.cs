using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterManager newsletterManager = new NewsletterManager(new EfNewsletterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(Newsletter newsletter)
        {
            newsletter.MailStatus = true;
            newsletterManager.TAdd(newsletter);
            return PartialView();
        }
    }
}
