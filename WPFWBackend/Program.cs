using Microsoft.EntityFrameworkCore;
using WPFWBackend.Data;
using WPFWBackend.Features.Projects.GetProjects;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQL") ??
    throw new InvalidOperationException("Connectionstring SQL is niet aanwezig. Check appsettings.json.");

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<WPFWDb>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<GetProjectsHandler>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hallo!");
app.MapGet("/hello/{id:int}", (int id) => $"Gevraagd: {id}");

app.Run();