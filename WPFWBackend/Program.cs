using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WPFWBackend.Data;
using WPFWBackend.Features.Auth;
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

//Zet identity function op User (UserManager en SignInManager) en voeg IdentityRole voor rollen service
builder.Services.AddIdentityApiEndpoints<User>()
    .AddRoles<IdentityRole>()             
    .AddEntityFrameworkStores<WPFWDb>();


//Registreert de autorisatieservices en de policy
builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Policies.CanEditContent, policy =>
        policy.RequireRole(Roles.Editor, Roles.Admin));

var app = builder.Build();

//Voeg de rollen toe aan de databse, en geef de services mee voor de scope
await RoleSeeder.SeedRoleAsync(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapProjectsEndpoints();
app.MapBlogsEndpoints();

app.Run();