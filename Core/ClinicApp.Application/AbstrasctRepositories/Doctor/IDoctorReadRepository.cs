using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Domain.Entities;


namespace ClinicApp.Application.AbstrasctRepositories
{
    public interface IDoctorReadRepository : IReadRepository<Doctors>
    {
        Task<IEnumerable<Doctors>> GetDoctorsAsync(string sortField, int page, int pageSize);
    }
}
