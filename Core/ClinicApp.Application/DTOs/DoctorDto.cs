using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities;

namespace ClinicApp.Application.DTOs
{
    public class DoctorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SpecializationId { get; set; }
        public string CabineId { get; set; }
        public string SectionId { get; set; }
     
    }
}
