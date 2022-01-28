using Przychodnia.Shared;

namespace Przychodnia.Client.Services
{
    public class AppDataService
    {
        public User account { get; set; }

        public List<Visit> visits { get; set; }

        public bool isLoggedIn { get { return account != null; } }
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
