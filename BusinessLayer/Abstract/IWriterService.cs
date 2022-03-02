using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        //Daha sonra bu fonksiyon adını düzelt
         List<Writer> GetWriterByID(int id);
    }
}
