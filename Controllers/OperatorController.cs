using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;

namespace AccessControl_backend.Controllers;

    public class OperatorController:CarterModule
    {
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/operator/getById/{id:int}", async (int id, AppDbContext context) =>
        {
            OperatorService service = new(context);
            var user = service.GetById(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        }
        );
        app.MapPost("/api/operator/create", async (OperatorDto user, AppDbContext context) =>
        {
            OperatorService service = new(context);
            var newUser = service.Create(user.Login, user.Password,user.UserId);
            return newUser != null ? Results.Ok(newUser) : Results.NotFound();
        }
        );

        app.MapGet("/api/operator/getAll", async (AppDbContext context) =>
        {
            OperatorService service = new(context);
            var users = await service.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }

    protected record OperatorDto(string Login, string Password,int UserId);
}