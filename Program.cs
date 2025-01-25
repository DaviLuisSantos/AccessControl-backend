using AccessControl_backend.Services;
using AccessControl_backend.Data;
using Microsoft.EntityFrameworkCore;
using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCarter();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=database.db"));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserFieldService>();
builder.Services.AddScoped<UserFieldValueService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapCarter();

app.Run();
