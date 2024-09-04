using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Persistence.Context
{
    public class ClinicAppContext : DbContext
    {
        public ClinicAppContext(DbContextOptions<ClinicAppContext> options) : base(options)
        {

        }

        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken= default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreationDate = DateTime.UtcNow, 
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,


                    _ => DateTime.UtcNow
                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
