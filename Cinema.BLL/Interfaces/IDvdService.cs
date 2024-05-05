using Cinema.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Interfaces
{
    public interface IDvdService
    { 
        IEnumerable<DvdModel> GetAll();
        DvdModel? GetById(int id);
        void Insert(DvdModel model);
        void Update(DvdModel model);
        void Delete(int id);
    }
}
