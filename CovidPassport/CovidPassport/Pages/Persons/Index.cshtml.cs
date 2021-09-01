using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

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

        public async Task OnGetAsync()
        {
            Person = await _context.People
                .Include(p => p.Address).ToListAsync();
        }
    }
}
