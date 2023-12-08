using HackerNewsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class HackerNewsControllerTests
{
    [Fact]
    public async Task GetBestStories_ReturnsCorrectResponse()
    {
        // Arrange
        var hackerNewsServiceMock = new Mock<IHackerNewsService>();
        hackerNewsServiceMock.Setup(s => s.GetBestStoryIdsAsync())
            .ReturnsAsync(new List<int> { 1, 2, 3 });

        hackerNewsServiceMock.Setup(s => s.GetStoryDetailsAsync(It.IsAny<int>()))
            .ReturnsAsync(new StoryDto
            {
                Title = "Test Story",
                Uri = "https://hacker-news.firebaseio.com/v0/item/21233041.json",
                PostedBy = "testuser",
                TimeUnix = 1638880000, // Replace with an appropriate Unix timestamp
                Score = 100,
                CommentCount = 20
            });

        var controller = new HackerNewsController(hackerNewsServiceMock.Object);

        // Act
        var result = await controller.GetBestStories(3) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);

        var stories = result.Value as List<StoryDto>;
        Assert.NotNull(stories);
        Assert.Equal(3, stories.Count);
        Assert.Equal("Test Story", stories.First().Title);
        // Add more assertions as needed
    }

}

