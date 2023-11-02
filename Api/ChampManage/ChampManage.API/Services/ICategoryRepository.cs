using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
