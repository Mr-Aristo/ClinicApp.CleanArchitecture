using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ClinicApp.Application.MediatR.Patient.Commands
{
    public class UpdatePatientCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public string Adres { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string SectionId { get; set; }
    }
}
