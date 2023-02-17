using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.DeleteShortenedLinkCommand
{
    public class DeleteShortenedLinkCommandHandler : IRequestHandler<DeleteShortenedLinkCommand, ShortenedCustomLink>
    {
        private readonly IShortenedLinkRepository _shortenedLinkRepository;
        public DeleteShortenedLinkCommandHandler(IShortenedLinkRepository shortenedLinkRepository)
        {
            _shortenedLinkRepository = shortenedLinkRepository;
        }
        public async Task<ShortenedCustomLink> Handle(DeleteShortenedLinkCommand request, CancellationToken cancellationToken)
        {
            var shortenedLink = await _shortenedLinkRepository.GetByIdAsync(request.Id);

            if (shortenedLink == null) return null;

            await _shortenedLinkRepository.DeleteAsync(shortenedLink);
            
            return shortenedLink;
        }
    }
}