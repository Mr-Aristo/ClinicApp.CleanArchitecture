using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities.Common;

namespace ClinicApp.Domain.Entities
{
    public class Sections : BaseEntity
    {         
        public int Number { get; set; }

        public ICollection<Patients> Patients { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
    }
}
