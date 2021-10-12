using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBooks.Pages.account
{
    public class google_loginModel : PageModel
    {
        public IActionResult OnGet(string ReturnUrl)
        {
            var properties = new AuthenticationProperties { RedirectUri = "account/google-response?ReturnUrl=" + ReturnUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}
