using Microsoft.AspNetCore.Mvc;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPlace.MyPlaceApi.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly MyPlaceDbContext _context;
        public ReservationController(MyPlaceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }




        // GET: api/reservation
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return _context.Reservations.ToList();
        }

        // GET api/reservation/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/reservation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/reservation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/reservation/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
