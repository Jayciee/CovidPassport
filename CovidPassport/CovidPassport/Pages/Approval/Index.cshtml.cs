using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.Approval
{
    public class IndexModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public IndexModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.People.Where(p => Convert.ToInt32(p.NoOfVaccines) >= 2).ToListAsync();
        }

        public Person GetPerson(int id)
        {
            return _context.People.Where(p => p.PersonId == id).FirstOrDefault();
        }

        public void CreatePassport(int id)
        {
            var details = GetPerson(id);
            Passport passportToBeAdded = new Passport() {
                PassportId = details.PersonId,
                PersonId = details.PersonId,
                ExpirationDate = DateTime.Now.AddYears(10),
                Picture = details.PersonId.ToString() + ".png",
                HealthCentreId = '1'
            };
            _context.Passports.Add(passportToBeAdded);
        }
    }
}
