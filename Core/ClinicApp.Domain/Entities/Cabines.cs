using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities.Common;

namespace ClinicApp.Domain.Entities
{
    public class Cabines : BaseEntity
    {
        public int Number { get; set; }

        public ICollection<Doctors> Doctors { get; set; }
    }
}
