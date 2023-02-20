using DevEncurtaUrl.Application.Commands.UpdateShortenedLink;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Commands
{
    public class UpdateShortenedLinkCommandHandlerTests
    {
        [Fact]
        public async Task ShortenedCustomLinkIsOk_Executed_UpdateDataAndSaveChangesAsyncAndReturnShortenedLink()
        {
            // Arrange
            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            var shortenedLink = new ShortenedCustomLink("github-thiagogonzalez Test", "https://github.com/Thiago-Gonzalez");

            shortenedLinkRepositoryMock.Setup(slr => slr.GetByIdAsync(shortenedLink.Id).Result).Returns(shortenedLink);

            var updateShortenedLinkCommand = new UpdateShortenedLinkCommand
            {
                Title = "github-thiagogonzalez Test Update",
                DestinationLink = "https://github.com/Thiago-Gonzalez"
            };

            updateShortenedLinkCommand.SetId(shortenedLink.Id);
            Assert.True(updateShortenedLinkCommand.Id == shortenedLink.Id);

            var updateShortenedLinkCommandHandler = new UpdateShortenedLinkCommandHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var link = await updateShortenedLinkCommandHandler.Handle(updateShortenedLinkCommand, new CancellationToken());

            // Assert
            Assert.NotNull(link);
            Assert.True(link.Id == shortenedLink.Id);
            Assert.True(link.Title == updateShortenedLinkCommand.Title);
            Assert.True(link.DestinationLink == updateShortenedLinkCommand.DestinationLink);

            shortenedLinkRepositoryMock.Verify(slr => slr.GetByIdAsync(shortenedLink.Id), Times.Once);
            shortenedLinkRepositoryMock.Verify(slr => slr.SaveChangesAsync(), Times.Once);
        }
    }
}