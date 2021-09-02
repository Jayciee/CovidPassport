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

        public IList<Person> PersonList { get;set; }

        public async Task OnGetAsync()
        {

            var OriginalList = await _context.People.Where(p => Convert.ToInt32(p.NoOfVaccines) >= 2).ToListAsync();

            var PassportList = _context.Passports.ToList();

            foreach (var person in OriginalList.ToList())
            {
                if (PassportList.Any(item => item.PersonId == person.PersonId))
                {
                    OriginalList.Remove(person);
                }

            }

            PersonList = OriginalList.Where(p => Convert.ToInt32(p.NoOfVaccines) >= 2).ToList();
        }

        public Person GetPerson(int id)
        {
            return _context.People.Where(p => p.PersonId == id).FirstOrDefault();
        }
    }
}
