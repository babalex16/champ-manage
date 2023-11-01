using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<Championship>> GetChampionshipsAsync();
        Task<Championship> GetChampionshipByIdAsync(int championshipId);
        void CreateChampionship(Championship championship);
        void DeleteChampionship(Championship championship);
        Task<IEnumerable<User>> GetParticipantsForChampionshipAsync(int championshipId);
        Task AddParticipantToChampionshipAsync(int championshipId, int userId);
        Task RemoveParticipantFromChampionshipAsync(int championshipId, int userId);
        Task<User> GetCreatorForChampionshipAsync(int championshipId);
        Task<IEnumerable<Championship>> GetChampionshipsCreatedByUserAsync(int userId);
        Task<bool> SaveChangesAsync();
    }
}
