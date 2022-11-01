using CourseworkAPI;
using CourseworkAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CarGameDatabaseSettings>(builder.Configuration.GetSection("CarGameDatabase"));

builder.Services.AddSingleton<PlayerService>();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();