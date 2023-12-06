using ChampManage.API.Data;
using ChampManage.API.Entities;
using ChampManage.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Services
{
    public class NewsRepository : INewsRepository
    {
        private readonly ChampManageContext _context;

        public NewsRepository(ChampManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddNews(News news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            _context.News.Add(news);
        }

        public void DeleteNews(News news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            _context.News.Remove(news);
        }

        public async Task<IEnumerable<News>> GetNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News?> GetNewsByIdAsync(int newsId)
        {
            return await _context.News.FirstOrDefaultAsync(n => n.Id == newsId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
