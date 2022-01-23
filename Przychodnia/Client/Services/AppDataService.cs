using Przychodnia.Shared;

namespace Przychodnia.Client.Services
{
    public class AppDataService
    {
        public User account { get; set; }

        public bool isLoggedIn { get { return account != null; } }
    }
}
