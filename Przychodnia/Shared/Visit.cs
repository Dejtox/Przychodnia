namespace Przychodnia.Shared
{
    public class Visit
    {
        
        public int VisitId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime  Date { get; set; }

        public int Duration { get; set; }

        public bool Paid { get; set; }

        public bool Successful { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

    }
}