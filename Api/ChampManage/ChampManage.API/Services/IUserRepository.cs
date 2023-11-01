using ChampManage.API.Entities;
using ChampManage.API.Models;

namespace ChampManage.API.Services
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetOrganizersAsync();
        Task<IEnumerable<User>> GetParticipantsAsync();
        Task<IEnumerable<Championship>> GetChampionshipsOfOrganizerAsync(int organizerId);
        Task<IEnumerable<Championship>> GetChampionshipsOfParticipantAsync(int participantId);
        Task<bool> UserExistsAsync(int userId);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> SaveChangesAsync();
        void DeleteUser(User user);
    }
}
