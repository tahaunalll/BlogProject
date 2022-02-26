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

        public void CommentAdd(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentDelete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {

            throw new NotImplementedException();
        }

        public List<Comment> GetCommentByID(int id)
        {
            GenericRepository<Comment> gr = new GenericRepository<Comment>();
            return gr.ListByFilter(x => x.CommentID == id);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
