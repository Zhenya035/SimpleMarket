using Microsoft.EntityFrameworkCore;
using SimpleMarket.Persistance;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SimpleMarketDbContext>(
    options =>
    {
        options.UseMySql(configuration.GetConnectionString(nameof(SimpleMarketDbContext)),
            new MySqlServerVersion(new Version(8, 0, 36)));
    }
    );

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");

app.Run();