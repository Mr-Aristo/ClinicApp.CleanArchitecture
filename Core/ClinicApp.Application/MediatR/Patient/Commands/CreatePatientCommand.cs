using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.Commands
{
    public class CreatePatientCommand : IRequest<PatientDto>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int DoctorId { get; set; }
    }
}
