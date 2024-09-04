using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Persistence.ConcreteRepositories.Patient;
using ClinicApp.Persistence.Context;

namespace ClinicApp.Persistence.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicAppContext _context;
        private PatientWriteRepository _patientWriteRepository;
        private PatientReadRepository _patientReadRepositoty;
        private DoctorReadRepository _doctorReadRepository;
        private DoctorWriteRepository _doctorWriteRepository;
        public UnitOfWork(ClinicAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IDoctorReadRepository DoctorReadRepository
        {
            get => _doctorReadRepository ??= new DoctorReadRepository(_context);
        }
        public IDoctorWriteRepository DoctorWriteRepository
        {
            get => _doctorWriteRepository ??= new DoctorWriteRepository(_context);
            set => _doctorWriteRepository = (DoctorWriteRepository)value;
        }

        public IPatientReadRepository PatientReadRepository
        {
            get=> _patientReadRepositoty ??= new PatientReadRepository(_context);
        }


        public IPatientWriteRepository PatientWriteRepository
        {
            get => _patientWriteRepository ??= new PatientWriteRepository(_context);
            set => _patientWriteRepository = (PatientWriteRepository)value;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public  async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }



}
