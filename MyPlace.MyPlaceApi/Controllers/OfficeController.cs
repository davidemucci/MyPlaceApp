using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Entities;
using MyPlace.BusinessLogic.Services;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Controllers
{

    [Route("api/building/{buildingId}/office")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly MyPlaceDbContext _context;
        private readonly IMyPlaceOfficeRepository _officeRepository;

        private readonly IMyPlaceBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public OfficeController(MyPlaceDbContext context, IMyPlaceOfficeRepository officeRepository,IMyPlaceBuildingRepository buildingRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _officeRepository = officeRepository ?? throw new ArgumentNullException(nameof(officeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _buildingRepository = buildingRepository ?? throw new ArgumentNullException(nameof(buildingRepository));
        }

       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeLightDto>>> GetOffices()
        {
            var offices = await _officeRepository.GetOfficesAsync();


            return Ok(_mapper.Map<IEnumerable<OfficeLightDto>>(offices));
        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeLightDto>>> GetOfficesForBuildingAsync(int buildingId)
        {
            var buildingExist = await _buildingRepository.ExistBuildingAsync(buildingId);

            if (!buildingExist)
            {
                return NotFound();
            }

            var offices = await _officeRepository.GetOfficesForBuildingAsync(buildingId);
            return Ok(_mapper.Map<IEnumerable<OfficeLightDto>>(offices));

        }
    }
}
