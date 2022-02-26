using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DataAccessLayer.ADO
{
    public class ADOBlogRepository : IBlogDal
    {
        ADOConnections acn = null;
        public void Create(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll()
        {
            List<Blog> blogList = new List<Blog>();
            acn = new ADOConnections();
            foreach (DataRow dr in  acn.stroredProcCommands("sp_GetAllBlogs").Rows)
            {
                blogList.Add(new Blog
                {
                    BlogID = Convert.ToInt32(dr["BlogID"]),
                    BlogTitle = dr["BlogTitle"].ToString(),
                    BlogContent = dr["BlogContent"].ToString(),
                    BlogThumbnailImaget = dr["BlogThumbnailImaget"].ToString(),
                    BlogImage=dr["BlogImage"].ToString(),
                    BlogCreateDate = Convert.ToDateTime(dr["BlogCreateDate"]),
                    BlogStatus = Convert.ToBoolean(dr["BlogStatus"]),
                    CategoryID = Convert.ToInt32(dr["CategoryID"])

                });
            }
            return blogList;
        }

        public List<Blog> GetListWithCategory()
        {
            throw new NotImplementedException();
        }



        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
