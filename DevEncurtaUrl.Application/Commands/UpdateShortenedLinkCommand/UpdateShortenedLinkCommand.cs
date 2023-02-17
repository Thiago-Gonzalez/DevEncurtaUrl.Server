using DevEncurtaUrl.Core.Entities;
using MediatR;

namespace DevEncurtaUrl.Application.Commands.UpdateShortenedLinkCommand
{
    public class UpdateShortenedLinkCommand : IRequest<ShortenedCustomLink>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DestinationLink { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}