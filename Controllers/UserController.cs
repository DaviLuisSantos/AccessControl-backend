using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;

namespace AccessControl_backend.Controllers;

public class UserController : CarterModule
{
    private readonly IUserService _userService;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user/getById/{id:int}", async (int id, AppDbContext context) =>
        {
            var user = _userService.GetUserById(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        }
        );
        app.MapPost("/api/user/create", async (UserDto user, AppDbContext context) =>
        {
            var newUser = _userService.Create(user.name,user.base64Image);
            return newUser != null ? Results.Ok(newUser) : Results.NotFound();
        }
        );

        app.MapGet("/api/user/getAll", async (AppDbContext context) =>
        {
            var users = await _userService.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }

    protected record UserDto(string name, string base64Image);

}

