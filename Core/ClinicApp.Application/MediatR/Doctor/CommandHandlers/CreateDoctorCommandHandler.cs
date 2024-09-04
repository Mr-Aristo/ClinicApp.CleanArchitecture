using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Doctor.Commands;
using ClinicApp.Domain.Entities;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.CommandHandlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctors
            {
                Name = request.Name,
                Specialization = request.Specialization
            };

            await _unitOfWork.DoctorWriteRepository.AddAsync(doctor);
            await _unitOfWork.SaveAsync();

            return new DoctorDto
            {
                Id = doctor.Id.ToString(),
                Name = doctor.Name,
                Specialization = doctor.Specialization
            };
        }
    }
}
