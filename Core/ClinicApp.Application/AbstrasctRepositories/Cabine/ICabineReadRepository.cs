using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Application.AbstrasctRepositories.Cabine
{
    public interface ICabineReadRepository : IReadRepository<Cabines>
    {
    }
}
