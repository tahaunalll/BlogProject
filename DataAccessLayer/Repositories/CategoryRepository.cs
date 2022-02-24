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
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void AddCategory(Category category)
        {
            //EntityFrameworkCore'a ait metotlar
            c.Add(category);

            //degişikleri kayddet
            c.SaveChanges();
        }

        public void Create(Category t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category t)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            //ef met
            c.Remove(category);

            //saving
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category getCategoryById(int categoryId)
        {
            return c.Categories.Find(categoryId);
        }

        public List<Category> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Category> ListAllCategories()
        {
            //
            return c.Categories.ToList();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            //ef met
            c.Update(category);

            //saving
            c.SaveChanges();
        }
    }
}
