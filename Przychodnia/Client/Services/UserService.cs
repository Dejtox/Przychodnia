using Przychodnia.Shared;
using System.Net.Http.Json;

namespace Przychodnia.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<User>>("api/users");
        }

        public Task<User> AddUser(User User)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Search(string Name, string Surname)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}
