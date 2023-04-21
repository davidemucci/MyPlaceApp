using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;
using MyPlace.BusinessLogic.Services;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly MyPlaceDbContext _context;
        private readonly IMyPlaceOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public OfficeController(MyPlaceDbContext context, IMyPlaceOfficeRepository officeRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _officeRepository = officeRepository ?? throw new ArgumentNullException(nameof(officeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeLightDto>>> GetOffices()
        {
            var offices = await _officeRepository.GetOfficesAsync();


            return Ok(_mapper.Map<IEnumerable<OfficeLightDto>>(offices));
        }
    }
}
