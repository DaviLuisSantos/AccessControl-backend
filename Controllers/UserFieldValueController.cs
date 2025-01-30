using AccessControl_backend.Data;
using AccessControl_backend.Models;
using AccessControl_backend.Services;
using Carter;

namespace AccessControl_backend.Controllers;

    public class UserFieldValueController:CarterModule
    {
    private readonly IUserFieldValueService _userFieldValueService;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/userFieldValue/create", async (UserFieldValueDto userField, AppDbContext context) =>
        {
            var newUserField = await _userFieldValueService.Create(userField.UserId, userField.UserFieldId, userField.Value);
            return newUserField != null ? Results.Ok(newUserField) : Results.NotFound();
        });
        app.MapGet("/api/userFieldValue/getAll", async (AppDbContext context) =>
        {
            var users = await _userFieldValueService.GetAll();
            return users != null ? Results.Ok(users) : Results.NotFound();
        }
        );
    }
    protected record UserFieldValueDto(int UserId, int UserFieldId, string Value);
}
