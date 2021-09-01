using System;
using System.Collections.Generic;

#nullable disable

namespace CovidPassport
{
    public partial class Person
    {
        public Person()
        {
            Passports = new HashSet<Passport>();
        }

        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string NoOfVaccines { get; set; }
        public DateTime Dob { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
    }
}
