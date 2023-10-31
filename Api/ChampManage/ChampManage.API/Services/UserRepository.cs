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
            return await _context.Users.FindAsync(userId);
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
            return await _context.Users.AnyAsync(u => u.Email == email);
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
            else
            {
                throw new DuplicateEmailException("Email is not unique.");  
            }
        }
    }
}
