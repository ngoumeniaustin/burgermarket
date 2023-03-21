using burger_market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace burger_market.Pages
{
    public class MenuBurgersModel : PageModel
    {
        private readonly burger_market.Data.DataContext _context;

        public MenuBurgersModel(burger_market.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Burger> Burger { get; set; }

        public async Task OnGetAsync()
        {
            Burger = await _context.Burgers.ToListAsync();
        }
    }
}
