using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicApp.Persistence
{
    public static class DataBaseConfiguration
    {
        public static string ConnectionString
        {
            get
            {

                ConfigurationManager configurationManager = new();                             // ../ bir geri cikma anlamina gelir.
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/E-ClinicApp.API"));
          
                configurationManager.AddJsonFile("appsettings.json");
                                              
                 return configurationManager.GetConnectionString("MsSQL");

            }
        }
    }
}
