using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities.Common;

namespace ClinicApp.Domain.Entities
{
    public class Doctors : BaseEntity
    {
        public string Name { get; set; }
        public Guid Cabine { get; set; }
        public Cabines Cabines { get; set; }

        public Guid SpecializationId { get; set; }
        public Specializations Specializations { get; set; }

        public Guid SectionId { get; set; }
        public Sections Sections { get; set; }

        public ICollection<Patients> Patients
        {
            get; set;
        }
    }
}

