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
            
            var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(request.Id, tracking: false);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found");
            }

          
            doctor.Name = request.Name;
          
       
            var updated = _unitOfWork.DoctorWriteRepository.Update(doctor);
            if (!updated)
            {
                throw new Exception("Failed to update the doctor");
            }

         
            await _unitOfWork.SaveAsync();

        }
    }

}
