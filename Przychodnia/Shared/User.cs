using Przychodnia.Shared;

namespace Przychodnia.Shared
{
    public class User
    {
        public string? Name { get; set; }

        public string? Surname { get; set; } 

        public long  ID { get; set; }

        public Role RoleName { get; set; }

        public int? RoleID { get; set; }

        public string PhotoPath { get; set; }
    }
}