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
    public class DeleteModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public DeleteModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HealthCentre HealthCentre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HealthCentre = await _context.HealthCentres
                .Include(h => h.Address).FirstOrDefaultAsync(m => m.HealthCentreId == id);

            if (HealthCentre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HealthCentre = await _context.HealthCentres.FindAsync(id);

            if (HealthCentre != null)
            {
                _context.HealthCentres.Remove(HealthCentre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
