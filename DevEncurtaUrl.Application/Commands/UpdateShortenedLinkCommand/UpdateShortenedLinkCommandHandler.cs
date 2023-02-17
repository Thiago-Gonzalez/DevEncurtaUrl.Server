using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.UpdateShortenedLinkCommand
{
    public class UpdateShortenedLinkCommandHandler : IRequestHandler<UpdateShortenedLinkCommand, ShortenedCustomLink>
    {
        private readonly IShortenedLinkRepository _shortenedLinkRepository;

        public UpdateShortenedLinkCommandHandler(IShortenedLinkRepository shortenedLinkRepository)
        {
            _shortenedLinkRepository = shortenedLinkRepository;
        }

        public async Task<ShortenedCustomLink> Handle(UpdateShortenedLinkCommand request, CancellationToken cancellationToken)
        {
            var shortenedLink = await _shortenedLinkRepository.GetByIdAsync(request.Id);

            if (shortenedLink == null) return null;

            shortenedLink.Update(request.Title, request.DestinationLink);

            await _shortenedLinkRepository.SaveChangesAsync();

            return shortenedLink;
        }
    }
}