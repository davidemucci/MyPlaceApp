using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public interface IMyPlaceOfficeRepository
    {
        Task<IEnumerable<Office>> GetOfficesAsync();
        Task<IEnumerable<Office>> GetOfficesForBuildingAsync(int buildingId);
    }
}
