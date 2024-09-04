using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.MediatR.Patient.Commands;
using FluentValidation;

namespace ClinicApp.Application.FluentValidation
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0.")
                .LessThanOrEqualTo(120).WithMessage("Age must be 120 or less.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId is required.");
        }
    }
}
