using AccessControl_backend.Models;

namespace AccessControl_backend.Services;

public interface IUserFieldService
{
    Task<List<UserField>> GetAll();
    Task<UserField> GetById(int id);
    Task<bool> Create(string name, string type, bool required, string? description);
    Task<UserField> Update(UserField userField);
    Task<bool> Delete(int id);
}
