using ChampManage.API.Data;
using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public void AddCategoryToChampionship(int championshipId, int categoryId)
        {
            var championshipCategory = new ChampionshipCategory
            {
                ChampionshipId = championshipId,
                CategoryId = categoryId
            };

            _context.ChampionshipCategories.Add(championshipCategory);
        }

        public void RemoveCategoryFromChampionship(int championshipId, int categoryId)
        {
            var championshipCategory = _context.ChampionshipCategories
                .FirstOrDefault(cc => cc.ChampionshipId == championshipId && cc.CategoryId == categoryId);

            if (championshipCategory != null)
            {
                _context.ChampionshipCategories.Remove(championshipCategory);
            }
        }

        public async Task<IEnumerable<Category>?> GetCategoriesForChampionshipAsync(int championshipId)
        {
            var championshipWithCategories = await _context.Championships
                 .Include(c => c.ChampionshipCategories)
                 .ThenInclude(cc => cc.Category)
                 .FirstOrDefaultAsync(c => c.Id == championshipId);

            if (championshipWithCategories == null)
            {
                return null;
            }

            return championshipWithCategories.ChampionshipCategories
                .Select(cc => cc.Category)
                .ToList();
        }

        public async Task<bool> CategoryExistsInChampionshipAsync(int championshipId, int categoryId)
        {
            // Check if the category with the specified ID is already associated with the championship
            return await _context.ChampionshipCategories
                .AnyAsync(cc => cc.ChampionshipId == championshipId && cc.CategoryId == categoryId);
        }

        //Marks the championship entity as modified, which signals to Entity
        //Framework that it should update the entity in the database the next time SaveChanges is called.
        public void UpdateChampionship(Championship championship)
        {
            _context.Entry(championship).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
