using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repositories
{
   public class DvdRepository : GenericRepository<Dvd>, IDvdRepository
    {
        public DvdRepository(DvdDbContext _context) : base(_context)
        { 
        }
    }
}
