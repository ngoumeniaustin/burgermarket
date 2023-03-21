using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using burger_market.Data;
using burger_market.Models;
using Microsoft.AspNetCore.Authorization;

namespace burger_market.Admin.Burgers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly burger_market.Data.DataContext _context;

       
        public DetailsModel(burger_market.Data.DataContext context)
        {
            _context = context;
        }

        public Burger Burger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Burger = await _context.Burgers.FirstOrDefaultAsync(m => m.BurgerID == id);

            if (Burger == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
