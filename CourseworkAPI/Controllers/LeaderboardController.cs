using CourseworkAPI.Models;
using CourseworkAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CourseworkAPI.Controllers;

[ApiController]
[Route("api/leaderboard")]
public class LeaderboardController : ControllerBase
{
    private readonly LeaderboardService _leaderboardService;

    public LeaderboardController(LeaderboardService leaderboardService) => _leaderboardService = leaderboardService;

    [HttpGet]
    public async Task<List<Player>> GetAsync() => await _leaderboardService.GetAsync();

    [HttpGet("limit/{limit:int}")]
    public async Task<List<Player>> GetAsync(int limit) => await _leaderboardService.GetAsync(limit);
}