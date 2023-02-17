using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevEncurtaUrl.Infrastructure.Persistence.Repositories
{
    public class ShortenedLinkRepository : IShortenedLinkRepository
    {
        private readonly DevEncurtaUrlDbContext _dbContext;
        public ShortenedLinkRepository(DevEncurtaUrlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ShortenedCustomLink shortenedLink)
        {
            await _dbContext.ShortenedLinks.AddAsync(shortenedLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ShortenedCustomLink shortenedLink)
        {
            _dbContext.ShortenedLinks.Remove(shortenedLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ShortenedCustomLink>> GetAllAsync()
        {
            return await _dbContext.ShortenedLinks.ToListAsync();
        }

        public async Task<ShortenedCustomLink> GetByCodeAsync(string code)
        {
            var shortenedLink = await _dbContext.ShortenedLinks.SingleOrDefaultAsync(sl => sl.Code == code);

            if (shortenedLink == null) return null;

            return shortenedLink;
        }

        public async Task<ShortenedCustomLink> GetByIdAsync(int id)
        {
            var shortenedLink = await _dbContext.ShortenedLinks.SingleOrDefaultAsync(sl => sl.Id == id);

            if (shortenedLink == null) return null;

            return shortenedLink;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}