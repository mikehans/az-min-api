using System.Security.Cryptography;
using DapperMinimalApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/weatherforecast", () => "Hello weather forecast" )
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/search/{name}", (string name) => $"Hello {name}");

app.MapGet("/search", ([FromQuery(Name="q")]string text) => $"Hi {text}");

PeopleHandler.MapEndpoints(app);

app.Run();
