using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CovidPassport;

namespace CovidPassport.Pages.HealthCentres
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
        ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "CompleteAddress");
            return Page();
        }

        [BindProperty]
        public HealthCentre HealthCentre { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HealthCentres.Add(HealthCentre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
