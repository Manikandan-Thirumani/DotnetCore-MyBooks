using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MyBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;


        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public void OnGet()
        {
            //MyBooks.Entity.Global.GlobalVariables.UserName = User.Identity.Name;
            MyBooks.Entity.Global.GlobalVariables.setGlobalVariable(User.Identity.Name, _config);

        }
    }
}
