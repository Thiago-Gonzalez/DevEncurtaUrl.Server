using DevEncurtaUrl.Application.ViewModels;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.AddShortenedLinkCommand
{
    public class AddShortenedLinkCommandHandler : IRequestHandler<AddShortenedLinkCommand, ShortenedLinkViewModel>
    {
        private readonly IShortenedLinkRepository _shortenedLinkRepository;
        public AddShortenedLinkCommandHandler(IShortenedLinkRepository shortenedLinkRepository)
        {
            _shortenedLinkRepository = shortenedLinkRepository;
        }

        public async Task<ShortenedLinkViewModel> Handle(AddShortenedLinkCommand request, CancellationToken cancellationToken)
        {
            var shortenedLink = new ShortenedCustomLink(request.Title, request.DestinationLink);

            await _shortenedLinkRepository.AddAsync(shortenedLink);

            return new ShortenedLinkViewModel(shortenedLink.Id, shortenedLink.Title, shortenedLink.ShortenedLink, shortenedLink.DestinationLink, shortenedLink.Code, shortenedLink.CreatedAt);
        }
    }
}