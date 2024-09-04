using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClinicAppContext>
    {
        public ClinicAppContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<ClinicAppContext> dbContextOptions = new();
           
             dbContextOptions.UseSqlServer(DataBaseConfiguration.ConnectionString);

            return new ClinicAppContext(dbContextOptions.Options); // read me de yazdigi gibi artik context const. ne alacagini biliyor
        }
    }
}
