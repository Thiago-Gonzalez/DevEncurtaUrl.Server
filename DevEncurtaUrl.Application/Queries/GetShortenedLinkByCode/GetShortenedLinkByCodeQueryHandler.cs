using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetShortenedLinkByCode
{
    public class GetShortenedLinkByCodeQueryHandler : IRequestHandler<GetShortenedLinkByCodeQuery, ShortenedCustomLink>
    {
        public readonly IShortenedLinkRepository _shortenedRepository;

        public GetShortenedLinkByCodeQueryHandler(IShortenedLinkRepository shortenedRepository)
        {
            _shortenedRepository = shortenedRepository;
        }

        public async Task<ShortenedCustomLink> Handle(GetShortenedLinkByCodeQuery request, CancellationToken cancellationToken)
        {
            var link = await _shortenedRepository.GetByCodeAsync(request.Code);

            if (link == null) return null;

            return link;
        }
    }
}