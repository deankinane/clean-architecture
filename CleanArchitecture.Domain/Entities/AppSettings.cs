using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ConnectionString { get; set; }
    }
}
