using CourseworkAPI.Models;
using CourseworkAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkAPI.Controllers;

[ApiController]
[Route("api/player")]
public class PlayerController : ControllerBase
{

    private readonly PlayerService _playerService;

    public PlayerController(PlayerService service) => _playerService = service;

    [HttpGet]
    public async Task<List<Player>> Get() => await _playerService.GetAsync();

    [HttpGet("id/{id:length(24)}")]
    public async Task<ActionResult<Player>> GetById(string id)
    {
        var player = await _playerService.GetByIdAsync(id);

        return player is null ? NotFound() : player;
    }
    
    [HttpGet("username/{username:length(3,16)}")]
    public async Task<ActionResult<Player>> GetByUsername(string username)
    {
        var player = await _playerService.GetByUsernameAsync(username);

        return player is null ? NotFound() : player;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Post(Player newPlayer)
    {
        await _playerService.CreateAsync(newPlayer);

        return CreatedAtAction(nameof(Get), new { id = newPlayer.Id }, newPlayer);
    }
}