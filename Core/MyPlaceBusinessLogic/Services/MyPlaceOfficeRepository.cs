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

        public async Task<IEnumerable<Office>> GetOfficesForBuildingAsync(int buildingId)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == buildingId);
            if(building is null)
            {
                throw new ArgumentNullException(nameof(building));
            }
            return await _context.Offices.Where(o => o.BuildingId ==  buildingId).ToListAsync();
        }
    }
}
