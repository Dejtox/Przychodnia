using Microsoft.EntityFrameworkCore;
using Przychodnia.Server.Services;
using Przychodnia.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Przychodnia.Server.Models
{
    public class VisitsRepository : IVisitsRepository
    {
        private readonly AppDb appDb;
        private readonly IMailService mailService;

        public VisitsRepository(AppDb appDb, IMailService mailService)
        {
            this.appDb = appDb;
            this.mailService = mailService;
        }

        public async Task<Visit> AddVisit(Visit visit)
        {

            var result = await appDb.Visits.AddAsync(visit);
            await appDb.SaveChangesAsync();
            mailService.test();
            return result.Entity;
        }

        public async Task DeleteVisit(int VisitId)
        {
            var result = await appDb.Visits.FirstOrDefaultAsync(e => e.VisitId == VisitId);

            if (result != null)
            {
                appDb.Visits.Remove(result);
                await appDb.SaveChangesAsync();
            }
        }

        public async Task<Visit> GetVisit(int VisitId)
        {
            return await appDb.Visits
                .FirstOrDefaultAsync(e => e.VisitId == VisitId);
        }

        public async Task<Visit> GetVisitByDoctorName(string PatientName)
        {
            return await appDb.Visits
                .FirstOrDefaultAsync(e => e.PatientName == PatientName);
        }

        public async Task<Visit> GetVisitByPatientName(string PatientName)
        {
            return await appDb.Visits
                .FirstOrDefaultAsync(e => e.PatientName == PatientName);
        }

        public async  Task<IEnumerable<Visit>> GetVisits()
        {
            await mailService.sendEmail("s.zellah10@gmail.com", "jest czwarta", "no jest czwarta, true");
            return await appDb.Visits.ToListAsync();
        }

        public async Task<IEnumerable<Visit>> Search(string Name, string doctorname, string patientname)
        {
            IQueryable<Visit> query = appDb.Visits;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.Name.Contains(Name));
            }

            if (doctorname != null)
            {
                query = query.Where(e => e.DoctorName == doctorname);
            }

            return await query.ToListAsync();
        }
        public async Task<Visit> UpdateVisit(Visit visit)
        {
            var result = await appDb.Visits
                .FirstOrDefaultAsync(e => e.VisitId == visit.VisitId);

            if (result != null)
            {
                result.Name = visit.Name;
                result.Description = visit.Description;
                result.Date = visit.Date;
                result.Duration = visit.Duration;
                result.Paid = visit.Paid;
                result.Successful = visit.Successful;
                result.PatientName = visit.PatientName;
                result.DoctorName = visit.DoctorName;

                await appDb.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
