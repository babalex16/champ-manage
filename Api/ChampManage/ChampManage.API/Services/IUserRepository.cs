using ChampManage.API.Entities;
using ChampManage.API.Models;

namespace ChampManage.API.Services
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetOrganizersAsync();
        Task<IEnumerable<User>> GetParticipantsAsync();
        Task<IEnumerable<Championship>> GetChampionshipsOfOrganizerAsync(int organizerId);
        Task<IEnumerable<Championship>> GetChampionshipsOfParticipantAsync(int participantId);
        Task<bool> UserExistsAsync(int userId);
        void DeleteUser(User user);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> CategoryExistsForUserInChampionship(int userId, int categoryId, int championshipId);
        void RegisterUserForCategory(UserCategoryRegistrationDto userCategoryRegistrationDto);
        Task<IEnumerable<User>> GetRegisteredUsersForCategory(int championshipId, int categoryId);
        Task<bool> SaveChangesAsync();
    }
}
