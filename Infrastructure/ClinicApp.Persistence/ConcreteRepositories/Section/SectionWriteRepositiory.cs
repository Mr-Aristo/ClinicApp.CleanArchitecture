using ClinicApp.Application.AbstrasctRepositories.Section;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Persistence.ConcreteRepositories.Section
{
    public class SectionWriteRepositiory : WriteRepository<Sections>,ISectionWriteRepository
    {
        public SectionWriteRepositiory(ClinicAppContext context): base (context)
        {

        }
    }
}
