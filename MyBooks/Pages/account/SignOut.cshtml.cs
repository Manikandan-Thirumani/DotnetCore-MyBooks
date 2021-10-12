using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBooks.Pages.account
{
    public class SignOutModel : PageModel
    {
        private const string V = "";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authservice;

        public SignOutModel(IHttpContextAccessor httpContextAccessor, IAuthenticationService authservice)
        {
            _httpContextAccessor = httpContextAccessor;
            _authservice = authservice;
        }

        public async Task<IActionResult> OnGet()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=https://localhost:44322");
        }
    }
}
