namespace DevEncurtaUrl.Application.ViewModels
{
    public class ShortenedLinkViewModel
    {
        public ShortenedLinkViewModel(int id, string title, string shortenedLink, string destinationLink, string code, string createdAt)
        {
            Id = id;
            Title = title;
            ShortenedLink = shortenedLink;
            DestinationLink = destinationLink;
            Code = code;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ShortenedLink { get; private set; }
        public string DestinationLink { get; private set; }
        public string Code { get; private set; }  
        public string CreatedAt { get; private set; }
    }
}