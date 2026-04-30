using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neon.CRM.Webapp.Data;
using Neon.CRM.Webapp.Data.Models;

namespace Neon.CRM.Webapp.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Neon.CRM.Webapp.Data.ApplicationDbContext _context;

        public CreateModel(Neon.CRM.Webapp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Customers"] = new SelectList(_context.Customers, "Id", "FullName");
        ViewData["VacationPackages"] = new SelectList(_context.VacationPackages, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Booking.BookingDate = Booking.BookingDate.ToUniversalTime();

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
