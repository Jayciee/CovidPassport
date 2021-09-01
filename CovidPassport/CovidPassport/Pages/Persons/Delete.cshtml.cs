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
    public class DeleteModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public DeleteModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.People.FindAsync(id);

            if (Person != null)
            {
                _context.People.Remove(Person);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
