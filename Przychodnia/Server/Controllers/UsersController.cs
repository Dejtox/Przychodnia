using Microsoft.AspNetCore.Mvc;
using Przychodnia.Shared;

namespace Przychodnia.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Marcel", "Krzysztof", "Franek", "Wiktoria", "Jakub", "Kinga",
        }; 
        private static readonly string[] Surnames = new[]
         {
        "Nowak", "Kowal", "Popielrz", "Sowa", "Pach", "Kulig",
        };
        private static readonly string[] Roles = new[]
         {
        "Doktor", "Pacjent",
        };

        

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Users
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Surname = Surnames[Random.Shared.Next(Surnames.Length)],
                Role = Roles[Random.Shared.Next(Roles.Length)]
            })
            .ToArray();
        }
    }
}
