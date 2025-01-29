using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl_backend.Controllers;

public class UserFieldController : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/userField/create", async (UserFieldDto userField, AppDbContext context) =>
        {
            UserFieldService service = new(context);
            var newUserField = await service.CreateUserField(userField.Name, userField.Type, userField.Required, userField.Description);
            return newUserField != null ? Results.Ok(newUserField) : Results.NotFound();
        });
        app.MapGet("/api/userField/getAll", async (AppDbContext context) =>
        {
            UserFieldService service = new(context);
            var users = await service.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }
    protected record UserFieldDto(string Name, string Type, bool Required, string? Description);
}

