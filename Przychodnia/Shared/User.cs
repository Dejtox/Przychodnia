using Przychodnia.Shared;

namespace Przychodnia.Shared
{
    public class User
    {
        public string? Name { get; set; }

        public string? Surname { get; set; } 

        public long  ID { get; set; }

        public Rang RangName { get; set; }

        public int? RangID { get; set; }

        public string PhotoPath { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        static public User Empty { get { return new User() { Name = "", Surname = "", ID = 0, PhotoPath = "", Email = "", Password = "" }; } }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}