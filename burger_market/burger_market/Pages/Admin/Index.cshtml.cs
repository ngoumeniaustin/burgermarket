using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using burger_market.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace burger_market.Pages.Admin
{
    public class IndexModel : PageModel
    {

        IConfiguration configuration;

        [BindProperty]
        public bool loginValid { get; set; } 
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.loginValid = true;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                
                return Redirect("Admin/Burgers");
            }
            return Page();
        }

        public async Task<IActionResult>  OnPostAsync( string username , string password, string ReturnUrl) {

            var authSection = configuration.GetSection("Auth");

            string adminlogin = authSection["AdminLogin"];
            string adminpassword = authSection["AdminPassword"];
            if ((username == adminlogin) && (password == adminpassword))
            {
                
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Burgers" : ReturnUrl);
            }
            loginValid = false;
            return Page();

        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Admin");
        }
    }
}
