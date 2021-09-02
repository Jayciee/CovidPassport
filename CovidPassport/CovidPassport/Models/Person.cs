using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CovidPassport
{
    public partial class Person
    {
        public Person()
        {
            Passports = new HashSet<Passport>();
        }
        [Required(ErrorMessage ="Missing NHS Number")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "NHS must only contain numbers.")]
        [MaxLength(9)] //Need to change to accept actual NHS Numbers
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Missing Address Id")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "MissingSurname")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-z]*$",ErrorMessage ="Surname must not contain numbers, special characters or spaces.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Missing Firstname")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Firstname must not contain numbers, special characters or spaces.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Missing Vaccine Number")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Number of Vaccines should be a single number between 0-9")]
        public string NoOfVaccines { get; set; }
        [Required(ErrorMessage = "Invalid or Missing DOB")]
        public DateTime Dob { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
    }
}
