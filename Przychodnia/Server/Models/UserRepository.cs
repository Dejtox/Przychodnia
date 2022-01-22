using Microsoft.EntityFrameworkCore;
using Przychodnia.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Przychodnia.Server.Models
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDb appDb;

        public UserRepository(AppDb appDb)
        {
            this.appDb = appDb;
        }
        public async Task<User> AddUser(User user)
        {
            var result = await appDb.Users.AddAsync(user);
            await appDb.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int ID)
        {
            var result = await appDb.Users.FirstOrDefaultAsync(e => e.ID == ID);

            if (result != null)
            {
                appDb.Users.Remove(result);
                await appDb.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int UserId)
        {
            return await appDb.Users
                .FirstOrDefaultAsync(e => e.ID == UserId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await appDb.Users
               .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDb.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Search(string Name, string Surname)
        {
            IQueryable<User> query = appDb.Users;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.Name.Contains(Name));
            }

            if (Surname != null)
            {
                query = query.Where(e => e.Surname == Surname);
            }

            return await query.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDb.Users
               .FirstOrDefaultAsync(e => e.ID == user.ID);

            if (result != null)
            {
                result.Name = user.Name;
                result.Surname = user.Surname;
                result.RangName = user.RangName;
                result.RangID = user.RangID;
                result.PhotoPath = user.PhotoPath;
                result.Email = user.Email;
                result.Password = user.Password;

                await appDb.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
