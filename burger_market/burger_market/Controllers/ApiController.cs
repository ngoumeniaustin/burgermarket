using burger_market.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace burger_market.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly burger_market.Data.DataContext _context;

        public ApiController(burger_market.Data.DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getBurgers")]
        public IActionResult GetBurgers()
        {
            
            return Json(_context.Burgers);
        }


    }
}
