using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CovidPassport.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public IndexModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Cities { get; set; }
        [BindProperty(SupportsGet = true)]
        public string City { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> cityQuery = from p in _context.People
                                            orderby p.Address.City
                                            select p.Address.City;

            var people = from p in _context.People select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                people = people.Where(s => s.FirstName.Contains(SearchString) ||
                    s.Surname.Contains(SearchString) ||
                    s.NoOfVaccines.Contains(SearchString) ||
                    Convert.ToString(s.PersonId).Contains(SearchString));
                Person = await people.ToListAsync();
            }

            Cities = new SelectList(await cityQuery.Distinct().ToListAsync());
            Person = await _context.People.Include(p => p.Address).ToListAsync();
        }
    }
}
