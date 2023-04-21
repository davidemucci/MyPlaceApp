using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public interface IMyPlaceBuildingRepository
    {
        Task<IEnumerable<Building>> GetBuildingsAsync();
        Task<bool> ExistBuildingAsync(int buildingId);
    }
}
