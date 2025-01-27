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
            UserField userFieldNew = new UserField { Name = userField.Name, Type = userField.Type, Required = userField.Required, Description = userField.Description };
            var newUserField = service.CreateUserField(userFieldNew);
            return newUserField != null ? Results.Ok(newUserField) : Results.NotFound();
        });
        }
    protected record UserFieldDto(string Name,string Type,bool Required,string? Description);
}

