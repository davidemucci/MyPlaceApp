using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Services
{
    public interface IMyPlaceUserRepository
    {
        void AddUser(User userToAdd);
        Task<bool> UserExistAsync(int userId);
        Task<bool> SaveAsync();
    }
}
