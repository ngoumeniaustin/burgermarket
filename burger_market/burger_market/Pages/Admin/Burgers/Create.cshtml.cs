using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using burger_market.Data;
using burger_market.Models;
using Microsoft.AspNetCore.Authorization;

namespace burger_market.Admin.Burgers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly burger_market.Data.DataContext _context;

        public CreateModel(burger_market.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Burger Burger { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Burgers.Add(Burger);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
