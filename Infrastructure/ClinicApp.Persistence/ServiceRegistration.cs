using ClinicApp.Application.AbstrasctRepositories;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Persistence.ConcreteRepositories;
using ClinicApp.Persistence.ConcreteRepositories.Patient;
using ClinicApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {

            
            services.AddDbContext<ClinicAppContext>(options => options.UseSqlServer(DataBaseConfiguration.ConnectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPatientReadRepository,PatientReadRepository>();
            services.AddScoped<IPatientWriteRepository,PatientWriteRepository>();

            services.AddScoped<IReadRepository,DoctorReadRepository>();
            services.AddScoped<IDoctorWriteRepository,DoctorWriteRepository>();

        }


    }
}
