using DevEncurtaUrl.Core.Entities;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.DeleteShortenedLink
{
    public class DeleteShortenedLinkCommand : IRequest<ShortenedCustomLink>
    {
        public DeleteShortenedLinkCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}