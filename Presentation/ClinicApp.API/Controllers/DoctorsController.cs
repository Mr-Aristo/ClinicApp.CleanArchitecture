using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Doctor.Commands;
using ClinicApp.Application.MediatR.Doctor.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors(string sortField = "Name", int page = 1, int pageSize = 10)
        {
            var query = new GetDoctorsQuery { SortField = sortField, Page = page, PageSize = pageSize };
            var doctors = await _mediator.Send(query);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(string id)
        {
            var query = new GetDoctorByIdQuery { Id = id };
            var doctor = await _mediator.Send(query);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> PostDoctor(CreateDoctorCommand command)
        {
            var doctor = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(string id, UpdateDoctorCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _mediator.Send(new DeleteDoctorCommand { Id = id });
            return NoContent();
        }
    }
}
