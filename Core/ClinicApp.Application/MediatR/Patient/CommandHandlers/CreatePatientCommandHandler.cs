using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Patient.Commands;
using ClinicApp.Domain.Entities;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.CommandHandlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patients
            {
                Name = request.Name,
                Surname = request.Surname,
                MiddleName = request.MiddleName,
                SectionId = Guid.Parse(request.SectionId),
                Age = request.Age,
                Adres = request.Adres

            };

            await _unitOfWork.PatientWriteRepository.AddAsync(patient);
            await _unitOfWork.SaveAsync();

            return new PatientDto
            {
                Id = patient.Id.ToString(),
                Name = patient.Name,
                Age = patient.Age,
                
            };
        }
    }
}
