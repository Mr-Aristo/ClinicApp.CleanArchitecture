using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories;
using ClinicApp.Domain.Entities;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class DoctorReadRepository : ReadRepository<Doctors>,IReadRepository
    {
        private ClinicAppContext _context;
        public DoctorReadRepository(ClinicAppContext context):base (context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Doctors>> GetDoctorsAsync(string sortField, int page, int pageSize)
        {
            var query = _context.Doctors.AsQueryable();

            switch (sortField.ToLower())
            {
                case "specialization":
                    query = query.OrderBy(d => d.Sections);
                    break;
                default:
                    query = query.OrderBy(d => d.Name);
                    break;
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
