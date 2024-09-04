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
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        async Task IRequestHandler<UpdateDoctorCommand>.Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing doctor entity
            var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(request.Id, tracking: false);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found");
            }

            // Update the doctor's properties with the values from the request
            doctor.Name = request.Name;
            doctor.Specialization = request.Specialization;

            // Update the entity in the database
            var updated = _unitOfWork.DoctorWriteRepository.Update(doctor);
            if (!updated)
            {
                throw new Exception("Failed to update the doctor");
            }

            // Save changes to the database
            await _unitOfWork.SaveAsync();

        }
    }

}
