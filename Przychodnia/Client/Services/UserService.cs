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
            var response = await httpClient.GetFromJsonAsync<IEnumerable<User>>("/api/users");

            foreach (User u in response)
            {
                if (u.RangID != null)
                    u.RangName = Rang.getRang((int)u.RangID);
            }
            return response;
        }

        public async Task<User> AddUser(User User)
        {
            var response = await httpClient.PostAsJsonAsync<User>("/api/users", User);
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public Task DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            return await httpClient.GetFromJsonAsync<User>($"api/users/mail/{Email}");
        }

        public Task<IEnumerable<User>> Search(string Name, string Surname)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(User User)
        {
            var response = await httpClient
             .PutAsJsonAsync<User>($"/api/users/{User.ID}", User);
            return await response.Content.ReadFromJsonAsync<User>();
        }
    }
}