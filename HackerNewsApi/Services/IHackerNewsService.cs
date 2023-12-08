using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsApi.Services
{
    public interface IHackerNewsService
    {
        Task<List<int>> GetBestStoryIdsAsync();
        Task<StoryDto> GetStoryDetailsAsync(int storyId);
        Task<HttpResponseMessage> GetStoryDetailsHttpResponseAsync(int storyId);
    }
}
