using DevEncurtaUrl.Application.ViewModels;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetShortenedLinkByIdQuery
{
    public class GetShortenedLinkByIdQueryHandler : IRequestHandler<GetShortenedLinkByIdQuery, ShortenedLinkViewModel>
    {
        private readonly IShortenedLinkRepository _shortenedLinkRepository;

        public GetShortenedLinkByIdQueryHandler(IShortenedLinkRepository shortenedLinkRepository)
        {
            _shortenedLinkRepository = shortenedLinkRepository;
        }

        public async Task<ShortenedLinkViewModel> Handle(GetShortenedLinkByIdQuery request, CancellationToken cancellationToken)
        {
            var link = await _shortenedLinkRepository.GetByIdAsync(request.Id);

            if (link == null) return null;

            return new ShortenedLinkViewModel(link.Id, link.Title, link.ShortenedLink, link.DestinationLink, link.Code, link.CreatedAt);
        }
    }
}