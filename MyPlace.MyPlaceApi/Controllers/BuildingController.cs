using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPlace.BusinessLogic.Contexts;
using MyPlace.BusinessLogic.Services;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly MyPlaceDbContext _context;
        private readonly IMyPlaceBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingController(MyPlaceDbContext context, IMyPlaceBuildingRepository buildingRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _buildingRepository = buildingRepository ?? throw new ArgumentNullException(nameof(buildingRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingLightDto>>> GetBuildings()
        {
            var buildings = await _buildingRepository.GetBuildingsAsync();

            return Ok(_mapper.Map<IEnumerable<BuildingLightDto>>(buildings));
        }

        
    }
}
