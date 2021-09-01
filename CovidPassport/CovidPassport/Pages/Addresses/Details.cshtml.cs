using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CovidPassport;

namespace CovidPassport.Pages.Addresses
{
    public class DetailsModel : PageModel
    {
        private readonly CovidPassport.PassportTrackerContext _context;

        public DetailsModel(CovidPassport.PassportTrackerContext context)
        {
            _context = context;
        }

        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.FirstOrDefaultAsync(m => m.AddressId == id);

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
