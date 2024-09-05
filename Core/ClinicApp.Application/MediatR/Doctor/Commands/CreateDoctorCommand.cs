using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.Commands
{
    public class CreateDoctorCommand : IRequest<DoctorDto>
    {
        public string Name { get; set; }
        public string SpecializationId { get; set; }
        public string CabineId { get; set; }
        public string SectionId { get; set; }
    }


}
