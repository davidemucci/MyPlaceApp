using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public class MyPlaceReservationRepository : IMyPlaceRepository
    {
        private readonly MyPlaceDbContext _context;

        public MyPlaceReservationRepository(MyPlaceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }

        public async Task<Reservation?> GetReservation(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.Id ==  id);
        }

        public async Task<Reservation?> GetReservationFromCode(Guid code)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationCode == code);
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public void UpdateReservation(Reservation reservation)
        {
           _context.Reservations.Update(reservation);
        }

        public async Task<bool> ReservationExistsAsync(int id)
        {
            if (await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id) is null)
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
