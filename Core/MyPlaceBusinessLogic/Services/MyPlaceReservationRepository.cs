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
    public class MyPlaceReservationRepository : IMyPlaceReservationRepository
    {
        private readonly MyPlaceDbContext _context;

        public MyPlaceReservationRepository(MyPlaceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //Getters
        public async Task<IEnumerable<Reservation>> GetReservationsForUserAsync(int userId)
        {
            return await _context.Reservations.Where(r => r.UserId == userId).ToListAsync();
        }
        public async Task<Reservation?> GetReservationForUserAsync(int id, int userId)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);
        }
        public async Task<Reservation?> GetReservationFromCodeAsync(Guid code)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationCode == code);
        }
        //Modifier
        public void AddReservation(Reservation reservation, int UserId)
        {
            if(reservation is null)
            {
                throw new ArgumentNullException(nameof(reservation));   
            }

            reservation.UserId = UserId;

            _context.Reservations.Add(reservation);
        }
        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {
           _context.Reservations.Update(reservation);
        }
        //Utilities
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
