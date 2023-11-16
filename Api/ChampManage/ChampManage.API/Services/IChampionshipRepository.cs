using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<Championship>> GetChampionshipsAsync();
        Task<Championship?> GetChampionshipByIdAsync(int championshipId);
        void CreateChampionship(Championship championship);
        void DeleteChampionship(Championship championship);
        Task<IEnumerable<User>> GetParticipantsForChampionshipAsync(int championshipId);
        Task AddParticipantToChampionshipAsync(int championshipId, int userId);
        Task RemoveParticipantFromChampionshipAsync(int championshipId, int userId);
        Task<User> GetCreatorForChampionshipAsync(int championshipId);
        Task<IEnumerable<Championship>> GetChampionshipsCreatedByUserAsync(int userId);
        void AddCategoryToChampionship(int championshipId, int categoryId);
        void RemoveCategoryFromChampionship(int championshipId, int categoryId);
        Task<IEnumerable<Category>> GetCategoriesForChampionshipAsync(int championshipId);
        Task<bool> CategoryExistsInChampionshipAsync(int championshipId, int categoryId);
        void UpdateChampionship(Championship championship);
        Task<bool> SaveChangesAsync();
    }
}
