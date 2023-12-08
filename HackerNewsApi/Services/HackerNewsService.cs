using HackerNewsApi.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class HackerNewsService : IHackerNewsService
{
    private readonly HttpClient _httpClient;

    public HackerNewsService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<int>> GetBestStoryIdsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<int>>("https://hacker-news.firebaseio.com/v0/beststories.json");
        return response;
    }
    public async Task<StoryDto> GetStoryDetailsAsync(int storyId)
    {
        var response = await _httpClient.GetFromJsonAsync<StoryDto>($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
        return response;
    }

    public async Task<HttpResponseMessage> GetStoryDetailsHttpResponseAsync(int storyId)
    {
        return await _httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
    }
}
