﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Application.AbstrasctRepositories.Repository;
using ClinicApp.Domain.Entities;

namespace ClinicApp.Application.AbstrasctRepositories.Patience
{
    public interface IPatientWriteRepository : IWriteRepository<Patients>
    {
    }
}
