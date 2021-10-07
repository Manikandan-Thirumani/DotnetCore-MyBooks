using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IHttpContextAccessor _httpContextAccessor;


        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            //_httpContextAccessor.HttpContext.Session.SetString("UserName","Manikandan");//TODO:need to change after login screen implemented.
            MyBooks.Entity.Global.GlobalVariables.UserName = "Manikandan";//TODO:need to change after login screen implemented.
        }
    }
}
