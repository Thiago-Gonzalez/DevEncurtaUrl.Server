using DevEncurtaUrl.Core.Entities;

namespace DevEncurtaUrl.Core.Repositories
{
    public interface IShortenedLinkRepository
    {
        Task<List<ShortenedCustomLink>> GetAllAsync();
        Task<ShortenedCustomLink> GetByIdAsync(int id);
        Task<ShortenedCustomLink> GetByCodeAsync(string code);
        Task AddAsync(ShortenedCustomLink shortenedLink);
        Task DeleteAsync(ShortenedCustomLink shortenedLink);
        Task SaveChangesAsync();
    }
}