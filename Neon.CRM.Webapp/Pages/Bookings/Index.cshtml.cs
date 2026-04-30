using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.Webapp.Data;
using Neon.CRM.Webapp.Data.Models;

namespace Neon.CRM.Webapp.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Neon.CRM.Webapp.Data.ApplicationDbContext _context;

        public IndexModel(Neon.CRM.Webapp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.VacationPackage).ToListAsync();
        }
    }
}
