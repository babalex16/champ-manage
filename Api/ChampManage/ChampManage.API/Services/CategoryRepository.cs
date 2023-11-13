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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        /*
        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<int> categoryIds)
        {
            return await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
        }*/

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Remove(category);
        }


        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }

}
