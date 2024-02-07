using MongoDB.Driver;
using mongodb_base_api.Models;
using mongodb_base_api.Services;
using mongodb_base_api.Repositories;
using mongodb_base_api.Infrastructure.Database;
using mongodb_base_api.Infrastructure.System.Models;
using mongodb_base_api.Infrastructure.System.Middlewares;
using mongodb_base_api.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add connection string
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Register mongoDb configuration as a singleton object
builder.Services.AddScoped( options => 
{
    var settings = builder.Configuration.GetSection("Settings").Get<Settings>()!;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<UserProfile>();
});

builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
