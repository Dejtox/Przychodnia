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
            Console.WriteLine(httpClient.BaseAddress);
            return await httpClient.GetFromJsonAsync<IEnumerable<Visit>>("api/visits");
        }

        public async Task AddVisit(Visit Visit)
        {
            try
            {
               var response = await httpClient.PostAsJsonAsync("api/visits", Visit);
            }
            catch(Exception ex)
            {
                Console.WriteLine("error >>>>>"+ex.Message);
            }
        }

        public Task DeleteVisit(int VisitId)
        {
            return httpClient.DeleteAsync($"api/visits/{VisitId}");
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

        public async Task<Visit> UpdateVisit(Visit Visit)
        {
            await httpClient.PutAsJsonAsync<Visit>($"api/visits/{Visit.VisitId}",Visit);
            return Visit;
        }
    }
}
