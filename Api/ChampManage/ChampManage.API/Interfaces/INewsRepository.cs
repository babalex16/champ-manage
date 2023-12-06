using ChampManage.API.Entities;

namespace ChampManage.API.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetNewsAsync();
        Task<News?> GetNewsByIdAsync(int newsId);
        void AddNews(News news);
        void DeleteNews(News news);
        Task<bool> SaveChangesAsync();

    }
}
