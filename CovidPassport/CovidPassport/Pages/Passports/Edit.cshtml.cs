using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.Passports
{
    public class EditModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public EditModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Passport Passport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Passport = await _context.Passports
                .Include(p => p.HealthCentre)
                .Include(p => p.Person).FirstOrDefaultAsync(m => m.PassportId == id);

            if (Passport == null)
            {
                return NotFound();
            }
           ViewData["HealthCentreId"] = new SelectList(_context.HealthCentres, "HealthCentreId", "Name");
           ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "FirstName");
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

            _context.Attach(Passport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportExists(Passport.PassportId))
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

        private bool PassportExists(int id)
        {
            return _context.Passports.Any(e => e.PassportId == id);
        }
    }
}
