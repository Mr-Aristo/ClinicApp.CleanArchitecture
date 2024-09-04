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
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        async Task IRequestHandler<DeletePatientCommand>.Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {

            var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(request.Id);
            if (patient == null) throw new KeyNotFoundException("Patient not found");

            _unitOfWork.PatientWriteRepository.Remove(patient);
            await _unitOfWork.SaveAsync();
        }
    }
}
