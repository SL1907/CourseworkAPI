using CourseworkAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CourseworkAPI.Services;

public class LeaderboardService
{
    private readonly IMongoCollection<Player> _playerCollection;

    public LeaderboardService(IOptions<CarGameDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _playerCollection = database.GetCollection<Player>(settings.Value.PlayersCollectionName);
    }

    public async Task<List<Player>> GetAsync(int limit = 10) =>
        await _playerCollection.Find(_ => true)
            .SortByDescending(player => player.HighScore)
            .Limit(limit)
            .ToListAsync();
    
}