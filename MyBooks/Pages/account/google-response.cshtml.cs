using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace MyBooks.Pages.account
{
    public class google_responseModel : PageModel
    {
        private readonly IAuthenticationService _authservice;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _config;


        public google_responseModel(IHttpContextAccessor httpContextAccessor, IAuthenticationService authservice, IConfiguration config)
        {
            _authservice = authservice;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
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
            //MyBooks.Entity.Global.GlobalVariables.UserName = User.Identity.Name;
            MyBooks.Entity.Global.GlobalVariables.setGlobalVariable(User.Identity.Name, _config);

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return new JsonResult(claims);
        }
    }
}
