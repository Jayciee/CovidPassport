using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CovidPassport
{
    public partial class Passport
    {
        [Required(ErrorMessage = "Missing Id")]
        public int PassportId { get; set; }
        [Required(ErrorMessage ="Missing Id")]
        [Compare(nameof(PassportId), ErrorMessage = "PassportId and PersonId do not match.")]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Missing Id")]
        public int HealthCentreId { get; set; }
        [Required(ErrorMessage = "Missing Picture Link")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "Missing Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        public virtual HealthCentre HealthCentre { get; set; }
        public virtual Person Person { get; set; }
    }
}
