using ClinicApp.Application.AbstrasctRepositories.Specialization;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Persistence.ConcreteRepositories.Specialization
{
    public class SpecializationWriteRepository : WriteRepository<Specializations>, ISecializationWriteRepository
    {
        public SpecializationWriteRepository(ClinicAppContext context) : base(context)
        {

        }
    }
}
