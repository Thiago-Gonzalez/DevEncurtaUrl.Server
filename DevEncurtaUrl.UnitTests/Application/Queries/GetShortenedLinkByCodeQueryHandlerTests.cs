using DevEncurtaUrl.Application.Queries.GetShortenedLinkByCode;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Queries
{
    public class GetShortenedLinkByCodeQueryHandlerTests
    {
        [Fact]
        public async Task ShortenedLinkExist_Executed_ReturnShortenedLink()
        {
            // Arrange
            var shortenedLink = new ShortenedCustomLink("github-tg-test2 Test2", "https://github.com/Thiago-Gonzalez");

            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            shortenedLinkRepositoryMock.Setup(slr => slr.GetByCodeAsync(shortenedLink.Code).Result).Returns(shortenedLink);

            var getShortenedLinkByCodeQuery = new GetShortenedLinkByCodeQuery(shortenedLink.Code);

            var getShortenedLinkByCodeQueryHandler = new GetShortenedLinkByCodeQueryHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var link = await getShortenedLinkByCodeQueryHandler.Handle(getShortenedLinkByCodeQuery, new CancellationToken());

            // Assert
            Assert.NotNull(link);

            shortenedLinkRepositoryMock.Verify(slr => slr.GetByCodeAsync(shortenedLink.Code).Result, Times.Once);
        }
    }
}