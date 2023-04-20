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
    public class MyPlaceUserRepository : IMyPlaceUserRepository
    {
        private readonly MyPlaceDbContext _context;

        public MyPlaceUserRepository(MyPlaceDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<bool> UserExistAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
