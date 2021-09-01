using System;
using System.Collections.Generic;

#nullable disable

namespace CovidPassport
{
    public partial class HealthCentre
    {
        public HealthCentre()
        {
            Passports = new HashSet<Passport>();
        }

        public int HealthCentreId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
    }
}
