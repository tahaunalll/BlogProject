using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        //sadece blog a özgü olan metotlar : 
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithCategoryByWriter(int id);
  
    }
}
