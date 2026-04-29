using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.Webapp.Data;
using Neon.CRM.Webapp.Data.Models;

namespace Neon.CRM.Webapp.Pages.Customers;

public class DetailsModel : PageModel
{
    private readonly Neon.CRM.Webapp.Data.ApplicationDbContext _context;

    public DetailsModel(Neon.CRM.Webapp.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

        if (customer is not null)
        {
            Customer = customer;

            return Page();
        }

        return NotFound();
    }
}
