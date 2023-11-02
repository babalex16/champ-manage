using ChampManage.API.Data;
using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ChampManageContext _context;

        public CategoryRepository(ChampManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetPredefinedCategories()
        {
            return await _context.Categories.ToListAsync();
        }

    }
}
