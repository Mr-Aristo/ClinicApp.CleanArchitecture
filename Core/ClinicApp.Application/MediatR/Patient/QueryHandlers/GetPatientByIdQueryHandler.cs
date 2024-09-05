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
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(request.Id,tracking:false);
            if (patient == null) return null;

            return new PatientDto
            {
                Id = patient.Id.ToString(),
                Name = patient.Name,
                Surname = patient.Surname,
                MiddleName = patient.MiddleName,
                Age = patient.Age,
                Adres = patient.Adres,
                Sex = patient.Sex             
            };
        }
    }
}
