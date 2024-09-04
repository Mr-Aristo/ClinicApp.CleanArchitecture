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
    public class CabineReadRepository:ReadRepository<Cabines>,ICabineReadRepository
    {
        public CabineReadRepository(ClinicAppContext context):base(context) 
        {

        }
    }
}
