using DevEncurtaUrl.Application.ViewModels;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetAllShortenedLinks
{
    public class GetAllShortenedLinksQueryHandler : IRequestHandler<GetAllShortenedLinksQuery, List<ShortenedLinkViewModel>>
    {
        private readonly IShortenedLinkRepository _shortenedLinkRepository;

        public GetAllShortenedLinksQueryHandler(IShortenedLinkRepository shortenedLinkRepository)
        {
            _shortenedLinkRepository = shortenedLinkRepository;
        }

        public async Task<List<ShortenedLinkViewModel>> Handle(GetAllShortenedLinksQuery request, CancellationToken cancellationToken)
        {
            var links = await _shortenedLinkRepository.GetAllAsync();

            var linksViewModel = links
                .Select(l => new ShortenedLinkViewModel(l.Id, l.Title, l.ShortenedLink, l.DestinationLink, l.Code, l.CreatedAt))
                .ToList();

            return linksViewModel;
        }
    }
}