using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;

namespace AccessControl_backend.Controllers;

public class UserController : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user/getById/{id:int}", async (int id, AppDbContext context) =>
        {
            UserService service = new(context);
            var user = service.GetUserById(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        }
        );
        app.MapPost("/api/user/create", async (UserDto user, AppDbContext context) =>
        {
            UserService service = new(context);
            var newUser = service.Create(user.name,user.base64Image);
            return newUser != null ? Results.Ok(newUser) : Results.NotFound();
        }
        );

        app.MapGet("/api/user/getAll", async (AppDbContext context) =>
        {
            UserService service = new(context);
            var users = await service.GetAllUsers();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }

    protected record UserDto(string name, string base64Image);

}

