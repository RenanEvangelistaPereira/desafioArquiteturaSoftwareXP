using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using webApiVendasOnline;
using webApiVendasOnline.Repositories;
using webApiVendasOnline.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var mongoDbPassword = configuration["ConnectionStrings:MongoDbPassword"];
var mongoDbConnectionString = configuration.GetConnectionString("MongoDb");
mongoDbConnectionString = mongoDbConnectionString?.Replace("{mongoDbPassword}", mongoDbPassword) ?? string.Empty;

builder.Services.Configure<YourMongoDbSettings>(options =>
{
    options.ConnectionString = mongoDbConnectionString;
    options.DatabaseName = configuration["YourMongoDbSettings:DatabaseName"];
});

// Register YourMongoDbSettings
builder.Services.Configure<YourMongoDbSettings>(configuration.GetSection("YourMongoDbSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<YourMongoDbSettings>>().Value);

// Register the repository and service
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
