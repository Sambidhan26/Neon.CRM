using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Neon.CRM.Webapp.Data;

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
        if (ModelState.IsValid)
        {
            //var agent = _context.Customers.Select(c => c.Agent)
            //    .Where(a => a != null)
            //    .Select(a => new { a.Id, FullName = $"{a.FirstName} {a.LastName}" })
            //    .ToList();
            var agents = _context.Users
                .Select(u => new { u.Id, FullName = $"{u.FirstName} {u.LastName}" })
                .ToList();
            ViewData["AgentId"] = new SelectList(agents, "Id", "Name");
        }
            return Page();
    }

    //[BindProperty]
    //public Customer Customers { get; set; } = default!;

    //// For more information, see https://aka.ms/RazorPagesCRUD.
    //public async Task<IActionResult> OnPostAsync()
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return Page();
    //    }

    //    _context.Customers.Add(Customers);
    //    await _context.SaveChangesAsync();

    //    return RedirectToPage("./Index");
    //}
}
