using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Patient.Queries;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.QueryHandlers
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _unitOfWork.PatientReadRepository.GetPatientsAsync(request.SortField, request.Page, request.PageSize);
            return patients.Select(p => new PatientDto
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Age = p.Age,
                //Doctor.nam = p.Doctor.Name
            }).ToList();
        }

      
    }
}
