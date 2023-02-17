using DevEncurtaUrl.Application.ViewModels;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetShortenedLinkByIdQuery
{
    public class GetShortenedLinkByIdQuery : IRequest<ShortenedLinkViewModel>
    {
        public GetShortenedLinkByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}