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
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _unitOfWork.DoctorReadRepository.GetDoctorsAsync(request.SortField, request.Page, request.PageSize);
            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id.ToString(),
                Name = d.Name,
                SpecializationId = d.SpecializationId.ToString()
            }).ToList();
        }
    }

}
