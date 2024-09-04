using ClinicApp.Application.AbstrasctRepositories.Cabine;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Persistence.ConcreteRepositories.Cabine
{
    public class CabineWriteRepository : WriteRepository<Cabines>, ICabineWriteRepository
    {
        public CabineWriteRepository(ClinicAppContext context) : base(context)
        {

        }
    }
}
