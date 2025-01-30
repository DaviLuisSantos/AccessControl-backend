using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl_backend.Controllers;

public class UserFieldController : CarterModule
{
    private readonly IUserFieldService _userFieldService;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/userField/create", async (UserFieldDto userField, AppDbContext context) =>
        {
            var newUserField = await _userFieldService.Create(userField.Name, userField.Type, userField.Required, userField.Description);
            return newUserField != null ? Results.Ok(newUserField) : Results.NotFound();
        });
        app.MapGet("/api/userField/getAll", async (AppDbContext context) =>
        {
            var users = await _userFieldService.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }
    protected record UserFieldDto(string Name, string Type, bool Required, string? Description);
}

