namespace Przychodnia.Shared
{
    public class Visits
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime  date { get; set; }

        public string? Duration { get; set; }

        public bool paid { get; set; }

        public bool successful { get; set; }

        public Users? PatientName { get; set; }

        public  Users? DoctorName { get; set; }

    }
}