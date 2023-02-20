using DevEncurtaUrl.Application.Queries.GetShortenedLinkById;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Queries
{
    public class GetShortenedLinkByIdQueryHandlerTests
    {
        [Fact]
        public async Task ShortenedLinkExist_Executed_ReturnShortenedLinkViewModel() 
        {
            // Arrange
            var shortenedLink = new ShortenedCustomLink("github-tg-test2 Test2", "https://github.com/Thiago-Gonzalez");

            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            shortenedLinkRepositoryMock.Setup(slr => slr.GetByIdAsync(shortenedLink.Id).Result).Returns(shortenedLink);

            var getShortenedLinkByIdQuery = new GetShortenedLinkByIdQuery(shortenedLink.Id);

            var getShortenedLinkByIdQueryHandler = new GetShortenedLinkByIdQueryHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var shortenedLinkViewModel = await getShortenedLinkByIdQueryHandler.Handle(getShortenedLinkByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(shortenedLinkViewModel);

            shortenedLinkRepositoryMock.Verify(slr => slr.GetByIdAsync(shortenedLink.Id).Result, Times.Once);
        }
    }
}