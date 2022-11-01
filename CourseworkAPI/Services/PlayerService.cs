using CourseworkAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CourseworkAPI.Services;

public class PlayerService
{
    private readonly IMongoCollection<Player> _playerCollection;

    public PlayerService(IOptions<CarGameDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _playerCollection = database.GetCollection<Player>(settings.Value.PlayersCollectionName);
        Console.WriteLine(GetAsync().Result.Count);
    }
    
    public async Task<List<Player>> GetAsync() =>
        await _playerCollection.Find(_ => true).ToListAsync();

    public async Task<Player?> GetByIdAsync(string id) =>
        await _playerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task<Player?> GetByUsernameAsync(string username) =>
        await _playerCollection.Find(x => x.Username == username).FirstOrDefaultAsync();

    public async Task CreateAsync(Player newPlayer) =>
        await _playerCollection.InsertOneAsync(newPlayer);

    public async Task UpdateAsync(string id, Player updatedPlayer) =>
        await _playerCollection.ReplaceOneAsync(x => x.Id == id, updatedPlayer);

    public async Task RemoveAsync(string id) =>
        await _playerCollection.DeleteOneAsync(x => x.Id == id);
}