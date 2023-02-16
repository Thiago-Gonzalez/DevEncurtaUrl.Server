namespace DevEncurtaUrl.Core.Entities
{
    public class ShortenedCustomLink
    {
        public ShortenedCustomLink(string title, string destinationLink)
        {
            var code = title.Split(" ")[0];

            Title = title;
            DestinationLink = destinationLink;
            ShortenedLink = $"localhost:3000/{code}";
            Code = code;
            CreatedAt = DateTime.Now.ToShortDateString();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ShortenedLink { get; private set; }
        public string DestinationLink { get; private set; }
        public string Code { get; private set; }  
        public string CreatedAt { get; private set; }

        public void Update(string title, string destinationLink)
        {
            Title = title;
            DestinationLink = destinationLink;
        }
    }
}