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

        public DbSet<Rang> Rangs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rang>().HasData(
                new Rang { RangID = 1, RangName = "Admin"}
            );
            modelBuilder.Entity<Rang>().HasData(
                new Rang { RangID = 2, RangName = "Doktor"}
            );
            modelBuilder.Entity<Rang>().HasData(
                new Rang { RangID = 3, RangName = "Pacjent"}
            );

            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Marcel",
                Surname="Kowal", 
                ID=995213523765,
                RangID=1,
                PhotoPath="Images/Marcel.png",
                Email="m.kowal@gmail.com",
                Password="MarcelKowal1"
            }
            );
            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Wiktoria",
                Surname="Tak", 
                ID=99768496534,
                RangID=2,
                PhotoPath="Images/Wiktoria.png",
                Email = "w.tak@gmail.com",
                Password = "Wika123"
            }
            );
            modelBuilder.Entity<User>().HasData( new User 
            { 
                Name = "Cezary",
                Surname="Muza", 
                ID=99574836547,
                RangID=3,
                PhotoPath="Images/Cezary.png",
                Email = "c.muza@gmail.com",
                Password = "Czarus14"
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
                PatientName= "Franek Kilimandżaro",
                DoctorName = "Cezary Ochlik"
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
                PatientName = "Kamil Sufranek",
                DoctorName = "Wiktoria Stępa"

            }
            );
        }
    }
}
