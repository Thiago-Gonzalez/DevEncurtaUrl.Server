using MediatR;

namespace DevEncurtaUrl.Application.Commands.UpdateShortenedLinkCommand
{
    public class UpdateShortenedLinkCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DestinationLink { get; set; }
    }
}