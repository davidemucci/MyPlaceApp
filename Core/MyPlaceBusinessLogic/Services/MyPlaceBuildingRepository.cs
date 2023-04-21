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
    public class MyPlaceBuildingRepository : IMyPlaceBuildingRepository
    {
        private readonly MyPlaceDbContext _context;

        public MyPlaceBuildingRepository(MyPlaceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }
    }
}
