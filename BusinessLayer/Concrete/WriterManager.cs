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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;
        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetById(int id)
        {
            return _writerdal.GetById(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterByID(int id)
        {
            GenericRepository<Writer> gr = new GenericRepository<Writer>();
            return gr.ListByFilter(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Create(t);
        }

        public void TDelete(Writer t)
        {
            _writerdal.Delete(t);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        
    }
}
