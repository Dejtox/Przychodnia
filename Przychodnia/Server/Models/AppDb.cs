using Microsoft.EntityFrameworkCore;
using Przychodnia.Shared;


namespace Przychodnia.Server.Models
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options)
            :base(options)
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin"}
            );
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 2, RoleName = "Doktor"}
            );
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 3, RoleName = "Pacjent"}
            );

            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Marcel",
                Surname="Kowal", 
                ID=995213523765,
                RoleID=1,
                PhotoPath="Images/Marcel.png"
            }
            );
            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Wiktoria",
                Surname="Tak", 
                ID=99768496534,
                RoleID=2,
                PhotoPath="Images/Wiktoria.png"
            }
            );
            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Cezary",
                Surname="Muza", 
                ID=99574836547,
                RoleID=3,
                PhotoPath="Images/Cezary.png"
            }
            );

            modelBuilder.Entity<Visit>().HasData( new Visit  
            { 
                Name = "Badanie",
                VisitId=1, 
                Description="Badanie Rozwojowe",
                Date= new DateTime(2022,1,11),
                Duration=3,
                Paid=true,
                Successful=true,
                //PatiientName=new User { Name="Cezary2", ID=3},
                //DocctorName=new User { Name="Cezary3", ID=4},
            }
            );
            modelBuilder.Entity<Visit>().HasData( new Visit  
            { 
                Name = "Badanie1",
                VisitId=2, 
                Description="Badanie Rozwojowe1",
                Date= new DateTime(2022,2,11),
                Duration=4,
                Paid=true,
                Successful=false,
                //PatiientName=new User { Name="Cezary", ID=1},
                //DocctorName=new User { Name="Cezary1", ID=2},
                
            }
            );
        }
    }
}
