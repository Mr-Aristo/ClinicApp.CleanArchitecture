using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Application.MediatR.Patient.Commands;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.CommandHandlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task IRequestHandler<UpdatePatientCommand>.Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(request.Id);
            if (patient == null) throw new KeyNotFoundException("Patient not found");

            patient.Name = request.Name;
            patient.Age = request.Age;
            patient.DoctorId = request.DoctorId;

            _unitOfWork.PatientWriteRepository.Update(patient);
            await _unitOfWork.SaveAsync();
        }
    }
}
