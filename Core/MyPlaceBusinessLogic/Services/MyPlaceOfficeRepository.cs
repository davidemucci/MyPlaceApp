using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public class MyPlaceOfficeRepository : IMyPlaceOfficeRepository
    {
        private readonly MyPlaceDbContext _context;

        public MyPlaceOfficeRepository(MyPlaceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Office>> GetOfficesAsync()
        {
            return await _context.Offices.ToListAsync();
        }
    }
}
