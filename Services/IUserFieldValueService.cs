using AccessControl_backend.Models;

namespace AccessControl_backend.Services;

public interface IUserFieldValueService
{
    Task<List<UserFieldValue>> GetAll();
    Task<UserFieldValue> GetById(int id);
    Task<bool> Create(int userId, int userFieldId, string value);
    Task<UserFieldValue> Update(UserFieldValue userFieldValue);
    Task<bool> Delete(int id);
}
