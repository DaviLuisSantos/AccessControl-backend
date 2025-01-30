using AccessControl_backend.Services;
using AccessControl_backend.Data;
using Microsoft.EntityFrameworkCore;
using Carter;
using AccessControl_backend.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCarter();
builder.AddAuth();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=database.db"));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFieldService,UserFieldService>();
builder.Services.AddScoped<IUserFieldValueService,UserFieldValueService>();
builder.Services.AddScoped<IOperatorService,OperatorService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();
// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Cria o banco de dados e as tabelas, se necessário, sem usar migrações
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapCarter();

app.Run();
