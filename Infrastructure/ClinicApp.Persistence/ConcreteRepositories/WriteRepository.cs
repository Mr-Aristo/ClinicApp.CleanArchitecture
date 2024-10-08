﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Domain.Entities.Common;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ClinicAppContext _context;

        public WriteRepository(ClinicAppContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(entity);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

      
        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
