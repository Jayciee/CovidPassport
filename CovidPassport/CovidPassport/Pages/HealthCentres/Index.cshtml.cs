using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.HealthCentres
{
    public class IndexModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public IndexModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public IList<HealthCentre> HealthCentre { get;set; }

        public async Task OnGetAsync()
        {
            HealthCentre = await _context.HealthCentres
                .Include(h => h.Address).ToListAsync();
        }
    }
}
