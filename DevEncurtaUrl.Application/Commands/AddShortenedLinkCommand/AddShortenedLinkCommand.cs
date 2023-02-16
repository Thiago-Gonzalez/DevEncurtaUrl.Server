using MediatR;

namespace DevEncurtaUrl.Application.Commands.AddShortenedLinkCommand
{
    public class AddShortenedLinkCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DestinationLink { get; set; }
    }
}