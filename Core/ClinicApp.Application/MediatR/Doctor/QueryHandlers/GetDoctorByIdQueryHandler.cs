using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.DTOs;
using ClinicApp.Application.MediatR.Doctor.Queries;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.QueryHandlers
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(request.Id,tracking:false);
            if (doctor == null) return null;

            return new DoctorDto
            {
                Id = doctor.Id.ToString(),
                Name = doctor.Name,
                SpecializationId = doctor.SpecializationId.ToString(),
               
            };
        }

    }
}

