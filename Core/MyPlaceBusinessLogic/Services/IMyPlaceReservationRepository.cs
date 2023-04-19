using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public interface IMyPlaceReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsForUserAsync(int id);
        Task<Reservation?> GetReservationForUserAsync(int id, int userId);
        Task<Reservation?> GetReservationFromCodeAsync(Guid code);
        void AddReservation(Reservation reservation, int userId);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<bool> ReservationExistsAsync(int id);
        Task<bool> SaveAsync();
    }
}
