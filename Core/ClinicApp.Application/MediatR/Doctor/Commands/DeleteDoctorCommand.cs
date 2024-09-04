using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicApp.Application.MediatR.Doctor.Commands
{
    public class DeleteDoctorCommand : IRequest
    {
        public string Id { get; set; }
    }
}
