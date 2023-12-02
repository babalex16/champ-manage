using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void CreateMatchesForChampionship(int championshipId);
        List<BracketNode> GetMatchesForChampionship(int championshipId);
        void DeleteMatchesForChampionship(int championshipId);
        string GetCategoryNameByChampionshipCategoryId(int championshipCategoryId);
        public int GetCategoryFightTimeByChampionshipCategoryId(int championshipCategoryId);
        public int GetCategoryMaxWeightByChampionshipCategoryId(int championshipCategoryId);
        public string GetCategoryBeltByChampionshipCategoryId(int championshipCategoryId);
        Task<bool> SaveChangesAsync();
    }
}
