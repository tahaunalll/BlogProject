using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _newsletterDal;
        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        
        public Newsletter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Newsletter t)
        {
            _newsletterDal.Create(t);
        }

        public void TDelete(Newsletter t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Newsletter t)
        {
            throw new NotImplementedException();
        }
    }
}
