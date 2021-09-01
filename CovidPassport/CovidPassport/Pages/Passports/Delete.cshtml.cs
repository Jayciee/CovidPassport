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
    public class DeleteModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public DeleteModel(CovidPassport.PassportTrackerContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Passport = await _context.Passports.FindAsync(id);

            if (Passport != null)
            {
                _context.Passports.Remove(Passport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
