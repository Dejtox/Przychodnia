using Przychodnia.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Przychodnia.Server.Models
{
    public interface IVisitsRepository
    {
        Task<IEnumerable<Visit>> Search(string Name, string doctorname, string patientname);
        Task<IEnumerable<Visit>> GetVisits();
        Task<Visit> GetVisit(int VisitId);
        Task<Visit> GetVisitByPatientName(string PatientName);
        Task<Visit> GetVisitByDoctorName(string PatientName);
        Task<Visit> AddVisit(Visit visit);
        Task<Visit> UpdateVisit(Visit visit);
        Task DeleteVisit(int VisitId);
    }
}
