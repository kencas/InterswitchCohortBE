using System.Reflection;
using API.Extensions;
using Infrastructure;
using Application;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Messaging;
using Infrastructure.Messaging.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Configuration
    .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureApplication(builder.Configuration);
//builder.Services.SeedDatabase(builder.Host);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
//builder.Host.UseSerilog(Logger.Configure);

var app = builder.Build();

using var scope = app.Services.CreateScope();
//await using var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
//await dbContext.Database.MigrateAsync();


var messagingService = scope.ServiceProvider.GetService<IRabbitMQManagementService>();

messagingService.ConsumeMessage("stock_update");

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
