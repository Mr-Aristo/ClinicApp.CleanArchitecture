using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Patient.Commands;
using ClinicApp.Application.MediatR.Patient.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients(string sortField = "Name", int page = 1, int pageSize = 10)
        {
            var query = new GetPatientsQuery { SortField = sortField, Page = page, PageSize = pageSize };
            var patients = await _mediator.Send(query);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(string id)
        {
            var query = new GetPatientByIdQuery { Id = id };
            var patient = await _mediator.Send(query);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> PostPatient(CreatePatientCommand command)
        {
            var patient = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(string id, UpdatePatientCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            await _mediator.Send(new DeletePatientCommand { Id = id });
            return NoContent();
        }
    }
}
