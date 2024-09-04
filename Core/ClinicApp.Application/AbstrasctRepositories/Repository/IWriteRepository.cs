using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities.Common;

namespace ClinicApp.Application.AbstrasctRepositories.Repository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T entity);
        
        Task<bool> RemoveAsync(string id);

        bool RemoveRange(List<T> datas);

        bool Update(T entity);

        Task<int> SaveAsync();
    }
}
