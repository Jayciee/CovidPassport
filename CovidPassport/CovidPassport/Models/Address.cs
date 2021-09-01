using System;
using System.Collections.Generic;

#nullable disable

namespace CovidPassport
{
    public partial class Address
    {
        public Address()
        {
            HealthCentres = new HashSet<HealthCentre>();
            People = new HashSet<Person>();
        }

        public int AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

        public virtual ICollection<HealthCentre> HealthCentres { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
