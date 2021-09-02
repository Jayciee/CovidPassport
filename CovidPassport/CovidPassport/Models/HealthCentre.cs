using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "AddressId Missing")]
        public int AddressId { get; set; }
        [Required(ErrorMessage ="Name of Establishment missing")]
        [StringLength(85)]
        [RegularExpression(@"^[A-Z][A-Za-z\s]*$")]
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
    }
}
