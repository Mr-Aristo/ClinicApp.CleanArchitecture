using ClinicApp.Domain.Entities;
using ClinicApp.Application.AbstrasctRepositories.Specialization; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence.ConcreteRepositories.Specialization
{
    public class SpecializationReadRepository : ReadRepository<Specializations>, ISecializationReadRepository
    {
        public SpecializationReadRepository(ClinicAppContext context ): base( context )
        {

        }
    }
}
