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
    public class google_responseModel : PageModel
    {
        private readonly IAuthenticationService _authservice;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public google_responseModel(IHttpContextAccessor httpContextAccessor, IAuthenticationService authservice)
        {
            _authservice = authservice;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> OnGet(string ReturnUrl)
        {
            var context = _httpContextAccessor.HttpContext;

            // var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var result = await _authservice.AuthenticateAsync(context, CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim =>
                    new
                    {
                        claim.Issuer,
                        claim.OriginalIssuer,
                        claim.Type,
                        claim.Value
                    });
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return new JsonResult(claims);
        }
    }
}
