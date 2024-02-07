using MongoDB.Driver;
using mongodb_base_api.Infrastructure.System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add connection string
builder.Services.Configure<Settings>(builder.Configuration.GetSection("DbSettings"));

// Register mongoDb configuration as a singleton object
builder.Services.AddScoped( options => 
{
    var settings = builder.Configuration.GetSection("DbSettings").Get<Settings>()!;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
