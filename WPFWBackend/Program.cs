using Microsoft.EntityFrameworkCore;
using WPFWBackend.Data;
using WPFWBackend.Features.Blogs;
using WPFWBackend.Features.Projects;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQL") ??
    throw new InvalidOperationException("Connectionstring SQL is niet aanwezig. Check appsettings.json.");

builder.Services.AddProjectsFeature();
builder.Services.AddBlogsFeature();
builder.Services.AddValidation();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<WPFWDb>(
    options => options.UseSqlServer(connectionString));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProjectsEndpoints();
app.MapBlogsEndpoints();

app.Run();