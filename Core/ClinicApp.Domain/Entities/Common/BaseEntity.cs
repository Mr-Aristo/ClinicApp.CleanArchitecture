﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
