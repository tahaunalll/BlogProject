using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        //CategoryRepository de global de tanımlamıştık;
        //Context c = new Context();
        public void AddBlog(Blog blog)
        {
            //farklı bir yapı kullanalım : 
            using var c = new Context();

            c.Add(blog);
            c.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            using var c = new Context();
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog getBlogById(int blogId)
        {
            using var c = new Context();
            return c.Blogs.Find(blogId);
        }

        public List<Blog> ListAllBlogs()
        {
            using var c = new Context();
            return c.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            using var c = new Context();
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
