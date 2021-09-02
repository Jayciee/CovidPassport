using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Invalid  House number")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Invalid  Street name")]
        [StringLength(85)]
        [RegularExpression(@"^[A-Z][a-z\s]*$")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Invalid City name")]
        [StringLength(85)]
        [RegularExpression(@"^[A-Z][a-z\s]*$")]
        public string City { get; set; }
        [Required(ErrorMessage = "Missing Postcode.")]
        [StringLength(8)]
        [RegularExpression(@"[A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9]\s[A-Z0-9][A-Z0-9][A-Z0-9]",ErrorMessage = "Invalid postcode. Correct format should be in [XXXX XXX]")]
        public string Postcode { get; set; }

        public virtual ICollection<HealthCentre> HealthCentres { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
