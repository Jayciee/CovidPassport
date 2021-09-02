using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.Approval
{
    public class EditModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public EditModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }
        public Person Person { get; set; }

        [BindProperty]
        public Passport Passport { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Person = await _context.People
                            .Include(p => p.Address).FirstOrDefaultAsync(m => m.PersonId == id);

   
            if (Person == null)
            {
                return NotFound();
            }
            ViewData["HealthCentreId"] = new SelectList(_context.HealthCentres, "HealthCentreId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Person = await _context.People
                            .Include(p => p.Address).FirstOrDefaultAsync(m => m.PersonId == id);
            try
            {
                Passport = new Passport()
                {
                    PassportId = Person.PersonId,
                    PersonId = Person.PersonId,
                    ExpirationDate = DateTime.Now.AddYears(10),
                    HealthCentreId = 1,
                    Picture = Person.PersonId + ".png"
                };

                _context.Passports.Add(Passport);
                // >---------- We Need To Look Into This -------------<
                //_context.Attach(Passport).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportCentreExists(Passport.PassportId))
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

        private bool PassportCentreExists(int id)
        {
            return _context.Passports.Any(e => e.PassportId == id);
        }
    }
}
