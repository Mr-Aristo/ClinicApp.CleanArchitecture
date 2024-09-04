using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.Commands
{
    public class DeletePatientCommand : IRequest
    {
        public string Id { get; set; }
    }
}
