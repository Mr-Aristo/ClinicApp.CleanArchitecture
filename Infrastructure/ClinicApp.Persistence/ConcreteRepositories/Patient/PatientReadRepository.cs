using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class PatientReadRepository : ReadRepository<Patients>, IPatientReadRepository
    {
        private readonly ClinicAppContext _context;
        public PatientReadRepository(ClinicAppContext context): base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Patients>> GetPatientsAsync(string sortField, int page, int pageSize)
        {
            //var query = _context.Patients.Include(p => p.Doctor).AsQueryable();

            //switch (sortField.ToLower())
            //{
            //    case "age":
            //        query = query.OrderBy(p => p.Age);
            //        break;
            //    case "doctorname":
            //        query = query.OrderBy(p => p.Doctor.Name);
            //        break;
            //    default:
            //        query = query.OrderBy(p => p.Name);
            //        break;
            //}

            //return await query
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();
            throw new NotImplementedException();    
        }
    }
}
