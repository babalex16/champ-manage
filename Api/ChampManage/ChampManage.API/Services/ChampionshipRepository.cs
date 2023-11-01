using ChampManage.API.Data;
using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Services
{
    public class ChampionshipRepository : IChampionshipRepository
    {
        private readonly ChampManageContext _context;
        public ChampionshipRepository(ChampManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Championship>> GetChampionshipsAsync()
        {
            return await _context.Championships.ToListAsync();
        }

        public async Task<Championship?> GetChampionshipByIdAsync(int championshipId)
        {
            return await _context.Championships.FindAsync(championshipId);
        }

        public void CreateChampionship(Championship championship)
        {
            _context.Championships.Add(championship);
        }

        public void DeleteChampionship(Championship championship )
        {
            _context.Championships.Remove(championship);
        }

        public async Task AddParticipantToChampionshipAsync(int championshipId, int userId)
        {
            var championship = await _context.Championships.FindAsync(championshipId);
            var user = await _context.Users.FindAsync(userId);

            if (championship != null && user != null)
            {
                championship.Participants.Add(user);
            }
        }

        public async Task RemoveParticipantFromChampionshipAsync(int championshipId, int userId)
        {
            var championship = await _context.Championships.FindAsync(championshipId);
            var user = await _context.Users.FindAsync(userId);

            if (championship != null && user != null)
            {
                championship.Participants.Remove(user);
            }
        }

        public async Task<IEnumerable<User>> GetParticipantsForChampionshipAsync(int championshipId)
        {
            return await _context.Users
                .Where(u => u.RegisteredChampionships.Any(c => c.Id == championshipId))
                .ToListAsync();
        }

        public async Task<User?> GetCreatorForChampionshipAsync(int championshipId)
        {
            return await _context.Users
                .Where(u => u.CreatedChampionships.Any(c => c.Id == championshipId))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Championship>> GetChampionshipsCreatedByUserAsync(int userId)
        {
            return await _context.Championships
                .Where(c => c.OrganizerId == userId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
