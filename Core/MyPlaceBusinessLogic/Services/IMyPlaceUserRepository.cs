using MyPlace.BusinessLogic.Entities;

namespace MyPlace.BusinessLogic.Services
{
    public interface IMyPlaceUserRepository
    {
        void AddUser(User userToAdd);
        Task<bool> UserExistAsync(int userId);
        Task<bool> SaveAsync();
    }
}
