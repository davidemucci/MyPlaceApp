using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;
using MyPlace.BusinessLogic.Services;

namespace MyPlace.MyPlaceApi.Helpers
{
    public class DbSeederInitial
    {
        //private readonly DbContext _context;
        private readonly IMyPlaceReservationRepository _repository;
        private readonly IMyPlaceUserRepository _userRepository;
        public DbSeederInitial(IMyPlaceReservationRepository repository, IMyPlaceUserRepository userRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void dbSeeder()
        {
            //Add 
            var user1 = new User()
            {
                FirstName = "Davide",
                LastName = "Mucci",
                Email = "davidemucci@email.com",
                Password = "password123"
            };

            var user2 = new User()
            {
                FirstName = "Greta",
                LastName = "Sarzi",
                Email = "gretasarzi@email.com",
                Password = "password123"
            };

            //Reservation

            var reservation1User1 = new Reservation()
            {
                //Id = 1,
                OfficeId = 1,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(15)),
            };

            var reservation2User1 = new Reservation()
            {
                //Id = 2,
                OfficeId = 1,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            var reservation3User1 = new Reservation()
            {
                //Id = 3,
                OfficeId = 2,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            var reservation4User1 = new Reservation()
            {
                //Id = 4,
                OfficeId = 2,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            /// User 2
            var reservation1User2 = new Reservation()
            {
                //Id = 5,
                OfficeId = 1,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(15)),
            };

            var reservation2User2 = new Reservation()
            {
                //Id = 6,
                OfficeId = 1,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            var reservation3User2 = new Reservation()
            {
                //Id = 7,
                OfficeId = 2,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            var reservation4User2 = new Reservation()
            {
                //Id = 8,
                OfficeId = 2,
                //UserId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
            };

            _userRepository.AddUser(user2);

            _repository.AddReservation(reservation1User1, 1);
            _repository.AddReservation(reservation2User1, 1);
            _repository.AddReservation(reservation3User1, 1);
            _repository.AddReservation(reservation4User1, 1);

            _repository.AddReservation(reservation1User2, 11);
            _repository.AddReservation(reservation2User2, 11);
            _repository.AddReservation(reservation3User2, 11);
            _repository.AddReservation(reservation4User2, 11);

        }
    }
}
