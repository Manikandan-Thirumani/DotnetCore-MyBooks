using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBooks.CommonHelpers;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;
using Newtonsoft.Json;

namespace MyBooks.Pages.AuthorsMaster
{
    [Authorize]

    public class IndexModel : PageModel
    {
        private readonly IAuthorsRepository _repo;
        private readonly IConfiguration _configuration;
        private readonly IWebApiConsumerHelper<IList<Authors>> _authorsHelper;

        public IndexModel(IAuthorsRepository repo, IConfiguration configuration, IWebApiConsumerHelper<IList<Authors>> authorsHelper)
        {
            _repo = repo;
            _configuration = configuration;
            _authorsHelper = authorsHelper;
        }

        public IList<Authors> Authors { get;set; }

        public async Task OnGetAsync()
        {
            if (MyBooks.Entity.Global.GlobalVariables.useWebApi)
            {
                
               // Authors =await WebApiConsumerHelper<IList<Authors>>.GetAsync("Authors");
               Authors = await _authorsHelper.ConsumeWebApi("Authors", HttpMethod.Get);
            }

            else
            {
                Authors = await _repo.GetAuthors();

            }
        }
    }
}
