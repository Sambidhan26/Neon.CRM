using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Neon.CRM.Webapp.Data;
using Neon.CRM.Webapp.Data.Models;

namespace Neon.CRM.Webapp.Pages.Customers;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        var agents = _context.Users
                .Select(q =>
                    new {
                        q.Id,
                        q.FirstName
                    }
                )
                .ToList();
        ViewData["AgentId"] = new SelectList(agents, "Id", "FirstName");
        return Page();
    }

    [BindProperty]
    public Customer Customers { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Customers.Add(Customers);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
