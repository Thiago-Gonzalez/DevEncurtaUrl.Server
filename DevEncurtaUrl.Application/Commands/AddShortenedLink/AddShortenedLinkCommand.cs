using DevEncurtaUrl.Application.ViewModels;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.AddShortenedLink
{
    public class AddShortenedLinkCommand : IRequest<ShortenedLinkViewModel>
    {
        public string Title { get; set; }
        public string DestinationLink { get; set; }
    }
}