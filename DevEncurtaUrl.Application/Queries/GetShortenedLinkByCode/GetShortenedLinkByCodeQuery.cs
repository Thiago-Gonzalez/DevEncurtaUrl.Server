using DevEncurtaUrl.Core.Entities;
using MediatR;

namespace DevEncurtaUrl.Application.Queries.GetShortenedLinkByCode
{
    public class GetShortenedLinkByCodeQuery : IRequest<ShortenedCustomLink>
    {
        public GetShortenedLinkByCodeQuery(string code)
        {
            Code = code;
        }
        
        public string Code { get; set; }
    }
}