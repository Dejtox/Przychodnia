using Przychodnia.Shared;

namespace Przychodnia.Client.Services
{
    public interface IVisitService
    {
        Task<IEnumerable<Visit>> Search(string Name, string doctorname, string patientname);
        Task<IEnumerable<Visit>> GetVisits();
        Task<Visit> GetVisit(int VisitId);
        Task<Visit> GetVisitByPatientName(string PatientName);
        Task<Visit> GetVisitByDoctorName(string PatientName);
        Task AddVisit(Visit visit);
        Task<Visit> UpdateVisit(Visit visit);
        Task DeleteVisit(int VisitId);
    }
}
