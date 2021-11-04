using Data;
using Data.Models;
using Data.Mongo;
using Data.Mongo.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppSettings.Init(builder.Services, builder.Configuration);

builder.Services.AddScoped<IMongoBaseContext, MongoDemoContext>();
builder.Services.AddScoped<IMongoRepository<Product>, MongoRepository<Product>>();
builder.Services.AddScoped<IMongoRepository<Order>, MongoRepository<Order>>();

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
