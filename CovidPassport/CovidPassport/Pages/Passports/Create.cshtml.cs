using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CovidPassport;

namespace CovidPassport.Pages.Passports
{
    public class CreateModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public CreateModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HealthCentreId"] = new SelectList(_context.HealthCentres, "HealthCentreId", "Name");
        ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "FirstName");
            return Page();
        }

        [BindProperty]
        public Passport Passport { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Passports.Add(Passport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
