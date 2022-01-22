using Przychodnia.Shared;
using System.Net.Http.Json;

namespace Przychodnia.Client.Services
{
    public class VisitService : IVisitService
    {
        private readonly HttpClient httpClient;

        public VisitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Visit>> GetVisits()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Visit>>("api/visits");
        }

        public Task<Visit> AddVisit(Visit Visit)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVisit(int VisitId)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> GetVisit(int VisitId)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> GetVisitByPatientName(string PatientName)
        {
            throw new NotImplementedException();
        }
        public Task<Visit> GetVisitByDoctorName(string DoctorName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Visit>> Search(string Name, string doctorname, string patientname)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> UpdateVisit(Visit Visit)
        {
            throw new NotImplementedException();
        }
    }
}
