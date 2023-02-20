using DevEncurtaUrl.Application.Queries.GetAllShortenedLinks;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Queries
{
    public class GetAllShortenedLinksQueryHandlerTests
    {
        [Fact]
        public async Task ThreeShortenedLinksExist_Executed_ReturnThreeShortenedLinkViewModelList() 
        {
            // Arrange
            var shortenedLinks = new List<ShortenedCustomLink>() {
                new ShortenedCustomLink("github-tg-test1 Test1", "https://github.com/Thiago-Gonzalez"),
                new ShortenedCustomLink("github-tg-test2 Test2", "https://github.com/Thiago-Gonzalez"),
                new ShortenedCustomLink("github-tg-test3 Test3", "https://github.com/Thiago-Gonzalez")
            };

            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            shortenedLinkRepositoryMock.Setup(slr => slr.GetAllAsync().Result).Returns(shortenedLinks);
            
            var getAllShortenedLinksQuery = new GetAllShortenedLinksQuery();

            var getAllShortenedLinksQueryHandler = new GetAllShortenedLinksQueryHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var shortenedLinkViewModelList = await getAllShortenedLinksQueryHandler.Handle(getAllShortenedLinksQuery, new CancellationToken());

            // Assert
            Assert.NotNull(shortenedLinkViewModelList);
            Assert.NotEmpty(shortenedLinkViewModelList);
            Assert.Equal(shortenedLinks.Count, shortenedLinkViewModelList.Count);

            shortenedLinkRepositoryMock.Verify(slr => slr.GetAllAsync().Result, Times.Once);
        }
    }
}