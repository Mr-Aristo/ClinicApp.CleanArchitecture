using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.DTOs;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.Queries
{
    public class GetPatientsQuery : IRequest<IEnumerable<PatientDto>>
    {
        public string SortField { get; set; } = "Name";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
