using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsApi.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HackerNewsController : ControllerBase
{
    private readonly IHackerNewsService _hackerNewsService;

    public HackerNewsController(IHackerNewsService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService;
    }

    [HttpGet("best/{n}")]
    public async Task<IActionResult> GetBestStories(int n)
    {
        var storyIds = await _hackerNewsService.GetBestStoryIdsAsync();
        var tasks = storyIds.Take(n).Select(id => _hackerNewsService.GetStoryDetailsAsync(id));

        var stories = await Task.WhenAll(tasks);
        var sortedStories = stories.OrderByDescending(s => s.Score).ToList();

        return Ok(sortedStories);
    }
}
