using Microsoft.AspNetCore.Authorization.Infrastructure;
using Portfolio.EntityModels;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Secret Manager path to db connection string;
string secretDBConnectionPath = "DBConnection:PostgresWebPortfolio";


// Register the DbContext
builder.Services.AddPostgreDbContext<PostgresWebPortfolioContext>(secretDBConnectionPath);
builder.Services.AddScoped<IClient, ClientRepository>(); 

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
