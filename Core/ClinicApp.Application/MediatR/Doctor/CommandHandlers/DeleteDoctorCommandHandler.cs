using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.MediatR.Doctor.Commands;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.CommandHandlers
{
    internal class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task IRequestHandler<DeleteDoctorCommand>.Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(request.Id);
            if (doctor == null) throw new KeyNotFoundException("Doctor not found");

            _unitOfWork.DoctorWriteRepository.Remove(doctor);
            await _unitOfWork.SaveAsync();
         
        }
    }
}
