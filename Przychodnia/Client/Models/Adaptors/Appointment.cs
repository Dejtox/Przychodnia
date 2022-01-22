using Przychodnia.Shared;

namespace Przychodnia.Client.Models.Adaptors
{
    public class Appointment
    {
        public Visit visit;
        public string Text { get { return visit.Name; } }
        public DateTime Start { get { return visit.Date; } }
        public DateTime End { get { return visit.Date.AddMinutes(visit.Duration); } }
    }
}
