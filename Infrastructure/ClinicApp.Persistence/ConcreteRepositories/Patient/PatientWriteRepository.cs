using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence.ConcreteRepositories.Patient
{
    public class PatientWriteRepository: WriteRepository<Patients>, IPatientWriteRepository
    {
        public PatientWriteRepository(ClinicAppContext context):base(context)
        {
            
        }
    }
}
