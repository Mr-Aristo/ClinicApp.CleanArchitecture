using ClinicApp.Application.AbstrasctRepositories;
using ClinicApp.Application.AbstrasctRepositories.Cabine;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Application.AbstrasctRepositories.Section;
using ClinicApp.Application.AbstrasctRepositories.Specialization;
using ClinicApp.Application.AbstrasctRepositories.UnitOfWork;
using ClinicApp.Persistence.ConcreteRepositories.Cabine;
using ClinicApp.Persistence.ConcreteRepositories.Patient;
using ClinicApp.Persistence.ConcreteRepositories.Section;
using ClinicApp.Persistence.ConcreteRepositories.Specialization;
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
        private SpecializationWriteRepository _specializationWriteRepository;
        private SpecializationReadRepository _specializationReadRepository;
        private SectionWriteRepositiory _sectionWriteRepository;
        private SectionReadRepositiory _sectionReadRepositiory;
        private CabineReadRepository _cabineReadRepository;
        private CabineWriteRepository _cabineWriteRepository;
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
            get => _patientReadRepositoty ??= new PatientReadRepository(_context);
        }


        public IPatientWriteRepository PatientWriteRepository
        {
            get => _patientWriteRepository ??= new PatientWriteRepository(_context);
            set => _patientWriteRepository = (PatientWriteRepository)value;
        }
        public ISecializationReadRepository SpecializationReadRepository { get => _specializationReadRepository ??= new SpecializationReadRepository(_context); }
        public ISecializationWriteRepository SpecializationWriteRepository
        {
            get => _specializationWriteRepository ??= new SpecializationWriteRepository(_context);
            set => _specializationWriteRepository = (SpecializationWriteRepository)value;
        }
        public ISectionReadRepository SectionReadRepository { get => _sectionReadRepositiory ??= new SectionReadRepositiory(_context); }
        public ISectionWriteRepository SectionWriteRepository
        {
            get => _sectionWriteRepository ??= new SectionWriteRepositiory(_context);
            set => _sectionWriteRepository = (SectionWriteRepositiory)value;
        }
        public ICabineReadRepository CabineReadRepository { get => _cabineReadRepository??= new CabineReadRepository(_context); }
        public ICabineWriteRepository CabineWriteRepository 
        { 
            get => _cabineWriteRepository??= new CabineWriteRepository(_context);
            set => _cabineWriteRepository = (CabineWriteRepository)value; 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }



}
