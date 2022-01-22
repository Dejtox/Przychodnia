using Przychodnia.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Przychodnia.Server.Models
{
    public interface IUserRepository
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
