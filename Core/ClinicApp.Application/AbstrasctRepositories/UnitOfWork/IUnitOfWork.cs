using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Cabine;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Application.AbstrasctRepositories.Patience;
using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Application.AbstrasctRepositories.Section;
using ClinicApp.Application.AbstrasctRepositories.Specialization;
using ClinicApp.Domain.Entities;

namespace ClinicApp.Application.AbstrasctRepositories.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IReadRepository DoctorReadRepository { get; }
        IDoctorWriteRepository DoctorWriteRepository { get; set; }

        IPatientReadRepository PatientReadRepository { get; }
        IPatientWriteRepository PatientWriteRepository { get; set; }

        ISecializationReadRepository SpecializationReadRepository { get; }  
        ISecializationWriteRepository SpecializationWriteRepository { get; set; }  

        ISectionReadRepository SectionReadRepository { get;  }
        ISectionWriteRepository SectionWriteRepository { get; set; }

        ICabineReadRepository CabineReadRepository { get; }
        ICabineWriteRepository CabineWriteRepository { get; set; }
    


            Task<int> SaveAsync();
    }
}
