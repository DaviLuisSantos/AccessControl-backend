using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;

namespace AccessControl_backend.Controllers;

    public class OperatorController:CarterModule
    {
    private readonly IOperatorService _operatorService;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/operator/getById/{id:int}", async (int id, AppDbContext context) =>
        {
            var user = _operatorService.GetById(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        }
        );
        app.MapPost("/api/operator/create", async (OperatorDto user, AppDbContext context) =>
        {
            var newUser = _operatorService.Create(user.Login, user.Password,user.UserId);
            return newUser != null ? Results.Ok(newUser) : Results.NotFound();
        }
        );

        app.MapGet("/api/operator/getAll", async (AppDbContext context) =>
        {
            var users = await _operatorService.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );

        app.MapPost("/api/login", async (LoginDto user, AppDbContext context) =>
        {
            Task<Operator>? userLogged = _operatorService.Login(user.Login, user.Password);
            return userLogged != null ? Results.Ok(userLogged) : Results.NotFound();
        }
        );

    }

    protected record OperatorDto(string Login, string Password,int UserId);
    protected record LoginDto(string Login, string Password);
}