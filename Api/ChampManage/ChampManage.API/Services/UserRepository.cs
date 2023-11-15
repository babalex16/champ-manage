using ChampManage.API.Data;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ChampManageContext _context;
        public UserRepository(ChampManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId).SingleOrDefaultAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Championship>> GetChampionshipsOfOrganizerAsync(int organizerId)
        {
            return await _context.Championships
                .Where(c => c.OrganizerId == organizerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Championship>> GetChampionshipsOfParticipantAsync(int participantId)
        {
            return await _context.Championships
                .Where(c => c.Participants.Any(p => p.Id == participantId))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetOrganizersAsync()
        {
            return await _context.Users
                .Where(u => u.UserType == UserType.Organizer)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetParticipantsAsync()
        {
            return await _context.Users
                .Where(u => u.UserType == UserType.Participant)
                .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !(await _context.Users.AnyAsync(u => u.Email == email));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task CreateUserAsync(User user)
        {
            if (await IsEmailUniqueAsync(user.Email))
            {
                _context.Users.Add(user);
            }
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.Users.AnyAsync(u => u.Id == userId);
        }

        public async Task<bool> CategoryExistsForUserInChampionship(int userId, int categoryId, int championshipId)
        {
            return await _context.UserCategoryRegistrations
                .AnyAsync(ucr =>
                    ucr.UserId == userId &&
                    ucr.CategoryId == categoryId &&
                    ucr.ChampionshipId == championshipId
                );
        }

        public void RegisterUserForCategory(UserCategoryRegistrationDto userCategoryRegistrationDto)
        {
            var userCategoryRegistration = new UserCategoryRegistration
            {
                UserId = userCategoryRegistrationDto.UserId,
                CategoryId = userCategoryRegistrationDto.CategoryId,
                ChampionshipId = userCategoryRegistrationDto.ChampionshipId
            };

            _context.UserCategoryRegistrations.Add(userCategoryRegistration);
        }

        public async Task<IEnumerable<User>> GetRegisteredUsersForCategory(int championshipId, int categoryId)
        {
            return await _context.UserCategoryRegistrations
                .Where(ucr => ucr.ChampionshipId == championshipId && ucr.CategoryId == categoryId)
                .Select(ucr => ucr.User)
                .ToListAsync();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
