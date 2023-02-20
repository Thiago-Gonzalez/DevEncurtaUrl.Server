using DevEncurtaUrl.Application.Commands.DeleteShortenedLink;
using DevEncurtaUrl.Core.Entities;
using DevEncurtaUrl.Core.Repositories;
using Moq;

namespace DevEncurtaUrl.UnitTests.Application.Commands
{
    public class DeleteShortenedLinkCommandHandlerTests
    {
        [Fact]
        public async Task ShortenedCustomLinkListIsOk_Executed_DeleteAsyncAndReturnShortenedLink()
        {
            // Arrange
            var shortenedLinkRepositoryMock = new Mock<IShortenedLinkRepository>();

            var shortenedLinks = new List<ShortenedCustomLink>() {
                new ShortenedCustomLink("github-tg-test1 Test1", "https://github.com/Thiago-Gonzalez"),
                new ShortenedCustomLink("github-tg-test2 Test2", "https://github.com/Thiago-Gonzalez"),
                new ShortenedCustomLink("github-tg-test3 Test3", "https://github.com/Thiago-Gonzalez")
            };

            var shortenedLink = shortenedLinks[0];

            shortenedLinkRepositoryMock.Setup(slr => slr.GetByIdAsync(shortenedLink.Id).Result).Returns(shortenedLink);

            shortenedLinkRepositoryMock.Setup(slr => slr.GetAllAsync().Result).Returns(shortenedLinks);

            var isActExecuted = false;
            shortenedLinkRepositoryMock.When(() => {
                if (isActExecuted) {
                    shortenedLinks.Remove(shortenedLink);
                }
                return isActExecuted;
            }).Setup(slr => slr.GetAllAsync().Result).Returns(shortenedLinks);
            
            var deleteShortenedLinkCommand = new DeleteShortenedLinkCommand(shortenedLink.Id);

            var deleteShortenedLinkCommandHandler = new DeleteShortenedLinkCommandHandler(shortenedLinkRepositoryMock.Object);

            // Act
            var link = await deleteShortenedLinkCommandHandler.Handle(deleteShortenedLinkCommand, new CancellationToken());

            isActExecuted = true;

            // Assert
            Assert.NotNull(link);
            Assert.NotEmpty(await shortenedLinkRepositoryMock.Object.GetAllAsync());
            Assert.DoesNotContain(shortenedLink, await shortenedLinkRepositoryMock.Object.GetAllAsync());

            shortenedLinkRepositoryMock.Verify(slr => slr.GetByIdAsync(shortenedLink.Id), Times.Once);
            shortenedLinkRepositoryMock.Verify(slr => slr.DeleteAsync(shortenedLink), Times.Once);
        }
    }
}