using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<Championship>> GetChampionshipsAsync();
        Task<Championship> GetChampionshipByIdAsync(int championshipId);
        Task CreateChampionshipAsync(Championship championship);
        Task DeleteChampionshipAsync(int championshipId);
        Task<IEnumerable<User>> GetParticipantsForChampionshipAsync(int championshipId);
        Task AddParticipantToChampionshipAsync(int championshipId, int userId);
        Task RemoveParticipantFromChampionshipAsync(int championshipId, int userId);
        Task<User> GetCreatorForChampionshipAsync(int championshipId);
        Task<IEnumerable<Championship>> GetChampionshipsCreatedByUserAsync(int userId);
    }
}
