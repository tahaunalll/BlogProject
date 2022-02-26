﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                //in order to provide 1-etarnal relationship --> join
                //Aim : @item.Category.CategoryName --> eager loading in view page
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
