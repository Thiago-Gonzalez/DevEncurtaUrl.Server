using DevEncurtaUrl.Application.Commands.AddShortenedLink;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Commands
{
    public class AddShortenedLinkCommandHandlerTests
    {
        [Fact]
        public async Task ShortenedCustomLinkIsOk_Executed_AddAsyncAndRetunShortenedLink() 
        {
            // Arrange
            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            var addShortenedLinkCommand = new AddShortenedLinkCommand
            {
                Title = "github-thiagogonzalez Test",
                DestinationLink = "https://github.com/Thiago-Gonzalez"
            };

            var addShortenedLinkCommandHandler = new AddShortenedLinkCommandHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var link = await addShortenedLinkCommandHandler.Handle(addShortenedLinkCommand, new CancellationToken());

            // Assert
            Assert.NotNull(link);

            shortenedLinkRepositoryMock.Verify(slr => slr.AddAsync(It.IsAny<DevEncurtaUrl.Core.Entities.ShortenedCustomLink>()), Times.Once);
        }
    }
}