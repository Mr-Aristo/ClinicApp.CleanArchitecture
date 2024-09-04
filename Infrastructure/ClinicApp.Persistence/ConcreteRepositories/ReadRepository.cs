using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Domain.Entities.Common;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ClinicAppContext _context;

        public ReadRepository(ClinicAppContext context)
        {
            _context = context;
        }

       public DbSet<T> Table => _context.Set<T>();

        public IQueryable GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T,bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(expression);
        }

    }
}
