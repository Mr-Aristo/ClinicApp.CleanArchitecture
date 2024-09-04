using ClinicApp.Application.AbstrasctRepositories.Section;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence.ConcreteRepositories.Section
{
    public class SectionReadRepositiory : ReadRepository<Sections>, ISectionReadRepository
    {
        public SectionReadRepositiory(ClinicAppContext context) : base(context)
        {

        }
    }
}
