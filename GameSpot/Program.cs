using FluentValidation.AspNetCore;
using FluentValidation;
using GameSpot.HealthChecks;
using GameSpot.BL.Interfaces;
using GameSpot.BL.Services;
using GameSpot.DL.Interfaces;
using GameSpot.DL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IGameRepository, GameRepository>();
builder.Services.AddSingleton<IPublisherRepository, PublisherRepository>();

builder.Services.AddSingleton<IGameService, GameService>();
builder.Services.AddSingleton<IPublisherService, PublisherService>();
builder.Services.AddSingleton<IGameSpotStoreService, GameSpotStoreService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

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

app.MapHealthChecks("/healthz");

app.Run();