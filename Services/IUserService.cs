using AccessControl_backend.Models;

namespace AccessControl_backend.Services;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User> GetUserById(int id);
    Task<bool> Create(string name, string base64Image);
    Task<User> Update(User user);
    Task<bool> DeleteUser(int id);
}
