﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        
        public List<Blog> GetBlogListByBlogID(int id)
        {
            //filter yöntemi sadece ef de olduğundan buradan initialize ettim
            GenericRepository<Blog> gr = new GenericRepository<Blog>();
            return gr.ListByFilter(x => x.BlogID==id);
        }

        public List<Blog> GetBlogListByWriterID(int id)
        {
            GenericRepository<Blog> gr = new GenericRepository<Blog>();
            return gr.ListByFilter(x => x.WriterID == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetBlogListWithCategory();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blogs()
        {
            //kontrol et
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public void TAdd(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
