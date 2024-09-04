using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities.Common;

namespace ClinicApp.Application.AbstrasctRepositories.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable GetAll(bool tracking = true);

        IQueryable GetWhere(Expression<Func<T,bool>> expression,bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T,bool>> expression, bool tracking = true); 

        Task<T> GetByIdAsync(string id,bool tracking = true);

    }
}
