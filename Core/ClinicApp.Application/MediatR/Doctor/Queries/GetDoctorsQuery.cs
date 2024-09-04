using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.Queries
{
    public class GetDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
    {
        public string SortField { get; set; } = "Name";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
