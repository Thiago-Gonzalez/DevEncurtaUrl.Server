using DevEncurtaUrl.Application.ViewModels;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetAllShortenedLinks
{
    public class GetAllShortenedLinksQuery : IRequest<List<ShortenedLinkViewModel>>
    {
    }
}