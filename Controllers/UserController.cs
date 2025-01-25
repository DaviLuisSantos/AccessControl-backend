using AccessControl_backend.Data;
using AccessControl_backend.Services;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl_backend.Controllers;

public class UserController : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user/getById/{id: int}", async (int id,AppDbContext context ) => 
        {
            UserService service = new(context);
            var user = service.GetUserById(id);
            return user != null ? Results.Ok(user) : Results.NotFound(); 
        }
        );
    }

}

