using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.HealthCentres
{
    public class EditModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public EditModel(CovidPassport.PassportTrackerContext context)
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
           ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "CompleteAddress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HealthCentre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthCentreExists(HealthCentre.HealthCentreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HealthCentreExists(int id)
        {
            return _context.HealthCentres.Any(e => e.HealthCentreId == id);
        }
    }
}
