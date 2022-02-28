using BusinessLayer.Abstract;
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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;
        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }


        public Comment GetById(int id)
        {

            throw new NotImplementedException();
        }

        public List<Comment> GetCommentByBlogID(int id)
        {
            GenericRepository<Comment> gr = new GenericRepository<Comment>();
            return gr.ListByFilter(x => x.BlogID == id);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment t)
        {
            _commentdal.Create(t);
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
