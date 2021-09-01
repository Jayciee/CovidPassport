using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.Passports
{
    public class IndexModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public IndexModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public IList<Passport> Passport { get;set; }

        public async Task OnGetAsync()
        {
            Passport = await _context.Passports
                .Include(p => p.HealthCentre)
                .Include(p => p.Person).ToListAsync();
        }
    }
}
