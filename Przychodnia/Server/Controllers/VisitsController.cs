using Przychodnia.Server.Models;
using Przychodnia.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Przychodnia.Server.Services;

namespace Przychodnia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitsRepository visitsRepository;
        private readonly IMailService mailService;
        private readonly IUserRepository userRepository;

        public VisitsController (IVisitsRepository visitsRepository, IMailService mailService, IUserRepository userRepository)
        {
            this.visitsRepository = visitsRepository;
            this.mailService = mailService;
            this.userRepository = userRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Visit>>> Search(string Name, string doctorname, string patientname)
        {
            try
            {
                var result = await visitsRepository.Search(Name, doctorname, patientname);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetVisits()
        {
            try
            {
                IEnumerable<Visit> visits = await visitsRepository.GetVisits();
                var attachments = mailService.allAttachmentNames();
                foreach(Visit v in visits)
                {
                    if (!v.Paid)
                    {
                        if(attachments.Contains(v.InvoiceNumber()+".txt"))
                        {
                            v.Paid = true;
                            await visitsRepository.UpdateVisit(v);
                        }
                    }
                }
                return Ok(visits);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            try
            {
                var result = await visitsRepository.GetVisit(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateVisit(Visit Visit)
        {
            try
            {
                if (Visit == null)
                    return BadRequest();

                var emp = await visitsRepository.GetVisitByPatientName(Visit.PatientName);

                /*if (emp != null)
                {
                    ModelState.AddModelError("Email", "Visit email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdVisit = await visitsRepository.AddVisit(Visit);
                var doctorMail = (await userRepository.GetUsers()).Where(u => $"{u.Name} {u.Surname}" == Visit.DoctorName).First().Email;
                var patientMail = (await userRepository.GetUsers()).Where(u => $"{u.Name} {u.Surname}" == Visit.PatientName).First().Email;
                await mailService.sendEmail(doctorMail,"Nowa wizyta", MailService.getMessageBody(MessageTypes.NewVisitToDoctor, Visit.DoctorName));
                await mailService.sendEmail(patientMail, "Utworzyłeś/łaś nową wizytę", MailService.getMessageBody(MessageTypes.NewVisitToPatient, Visit.PatientName));
                return CreatedAtAction(nameof(GetVisit),
                    new { id = createdVisit.VisitId }, createdVisit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Visit record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Visit>> UpdateVisit(int id, Visit Visit)
        {
            try
            {
                if (id != Visit.VisitId)
                    return BadRequest("Visit ID mismatch");

                var VisitToUpdate = await visitsRepository.GetVisit(id);

                if (VisitToUpdate == null)
                {
                    return NotFound($"Visit with Id = {id} not found");
                }

                return await visitsRepository.UpdateVisit(Visit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating Visit record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            try
            {
                var VisitToDelete = await visitsRepository.GetVisit(id);

                if (VisitToDelete == null)
                {
                    return NotFound($"Visit with Id = {id} not found");
                }

                await visitsRepository.DeleteVisit(id);

                return Ok($"Visit with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting Visit record");
            }
        }
    }
}