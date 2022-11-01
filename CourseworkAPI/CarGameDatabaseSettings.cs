namespace CourseworkAPI;

public class CarGameDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PlayersCollectionName { get; set; } = null!;
}