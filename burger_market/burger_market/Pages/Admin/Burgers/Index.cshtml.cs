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
    public class IndexModel : PageModel
    {
        private readonly burger_market.Data.DataContext _context;

        public IndexModel(burger_market.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Burger> Burger { get;set; }

        public async Task OnGetAsync()
        {
            Burger = await _context.Burgers.ToListAsync();
        }
    }
}
