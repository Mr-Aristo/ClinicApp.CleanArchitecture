using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class DoctorWriteRepository : WriteRepository<Doctors>, IDoctorWriteRepository
    {
        public DoctorWriteRepository(ClinicAppContext context): base(context) 
        {
            
        }
    }
}
