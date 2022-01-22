using Przychodnia.Shared;

namespace Przychodnia.Client.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Search(string Name, string Surname);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int ID);
    }
}
