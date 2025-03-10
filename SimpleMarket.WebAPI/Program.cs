using Microsoft.EntityFrameworkCore;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Persistance;
using SimpleMarket.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<AddressService>();

builder.Services.AddScoped<ICartRepository, CartRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

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
app.MapControllers();

app.Run();