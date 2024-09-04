using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Doctor;
using ClinicApp.Application.AbstrasctRepositories.Patience;

namespace ClinicApp.Application.AbstrasctRepositories.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IDoctorReadRepository DoctorReadRepository { get; }
        IDoctorWriteRepository DoctorWriteRepository { get; set; }

        IPatientReadRepository PatientReadRepository { get; }
        IPatientWriteRepository PatientWriteRepository { get; set; }


       
        Task<int> SaveAsync();
    }
}
