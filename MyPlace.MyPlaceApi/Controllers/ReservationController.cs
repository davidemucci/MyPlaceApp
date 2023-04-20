using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Dtos;
using MyPlace.BusinessLogic.Entities;
using MyPlace.BusinessLogic.Services;
using MyPlace.MyPlaceApi.Helpers;
using MyPlace.MyPlaceApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPlace.MyPlaceApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/users/{userId}/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly MyPlaceDbContext _context;
        private readonly IMyPlaceReservationRepository _repository;
        private readonly IMyPlaceUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ReservationController(MyPlaceDbContext context, IMapper autoMapper, IMyPlaceReservationRepository repository, IMyPlaceUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet(Name = "GetReservationsForUser")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsForUser(int userId)
        {

            if (!await _userRepository.UserExistAsync(userId))
            {
                return NotFound();
            }

            var reservations = await _repository.GetReservationsForUserAsync(userId);
            var reservationToReturn = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            return Ok(reservationToReturn);
        }

        [HttpGet("{reservationId}", Name = "GetReservationForUser")]
        public async Task<ActionResult<ReservationDto>> GetReservation(int reservationId, int userId)
        {
            if (!await _userRepository.UserExistAsync(userId))
            {
                return NotFound($"User with {userId} id not found");
            }

            var reservation = await _repository.GetReservationForUserAsync(reservationId, userId);

            if (reservation == null)
            {
                return NotFound($"Reservation with id {reservationId} wasn't found associated to the user");
            }

            var reservationToReturn = _mapper.Map<ReservationDto>(reservation);

            return Ok(reservationToReturn);

        }

        [HttpPost(Name = "CreateReservationForUser")]
        public async Task<ActionResult> AddReservationForuser(ReservationForManipulationDto reservationDto, int userId)
        {
            if (reservationDto is null)
            {
                return BadRequest("Some problem with Reservation object");
            }

            if (!await _userRepository.UserExistAsync(userId))
            {
                return NotFound($"User with id {userId} wasn't found");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var date = DateOnly.FromDateTime(reservationDto.Date);

            if ( date < DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest("Date should be in the future");
            }

            var reservationEntity = _mapper.Map<Reservation>(reservationDto);

            _repository.AddReservation(reservationEntity, userId);
             await _repository.SaveAsync();

            var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity);

            return CreatedAtRoute("GetReservationForUser",
                new { userId, reservationId = reservationEntity.Id },
                reservationToReturn);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{reservationId}")]
        public async Task<ActionResult> Delete(int reservationId, int userId)
        {
            if (!await _userRepository.UserExistAsync(userId))
            {
                return NotFound();
            }

            var relationToDelete = await _repository.GetReservationForUserAsync(reservationId, userId);

            if (relationToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteReservation(relationToDelete);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
