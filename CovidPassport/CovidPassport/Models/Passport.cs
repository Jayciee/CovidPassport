using System;
using System.Collections.Generic;

#nullable disable

namespace CovidPassport
{
    public partial class Passport
    {
        public int PassportId { get; set; }
        public int PersonId { get; set; }
        public int HealthCentreId { get; set; }
        public string Picture { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual HealthCentre HealthCentre { get; set; }
        public virtual Person Person { get; set; }
    }
}
