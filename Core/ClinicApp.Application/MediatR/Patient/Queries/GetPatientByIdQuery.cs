using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.Queries
{
    public class GetPatientByIdQuery : IRequest<PatientDto>
    {
        public string Id { get; set; }
    }
}
