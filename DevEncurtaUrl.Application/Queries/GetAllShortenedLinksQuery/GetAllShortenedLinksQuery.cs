using DevEncurtaUrl.Application.ViewModels;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetAllShortenedLinksQuery
{
    public class GetAllShortenedLinksQuery : IRequest<List<ShortenedLinkViewModel>>
    {
    }
}