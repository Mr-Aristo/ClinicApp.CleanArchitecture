using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.Queries
{
    public class GetDoctorByIdQuery:IRequest<DoctorDto>
    {
        public string Id { get; set; }
    }
}
