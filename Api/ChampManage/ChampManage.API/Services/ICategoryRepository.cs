using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        //Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<int> categoryIds);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void CreateMatchesForChampionship(int championshipId);
        List<BracketNode> GetMatchesForChampionship(int championshipId);
        void DeleteMatchesForChampionship(int championshipId);
        Task<bool> SaveChangesAsync();
    }
}
