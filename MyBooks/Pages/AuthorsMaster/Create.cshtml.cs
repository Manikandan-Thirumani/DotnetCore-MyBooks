using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBooks.CommonHelpers;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;
using Newtonsoft.Json;

namespace MyBooks.Pages.AuthorsMaster
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IAuthorsRepository _repo ;
        private readonly IWebApiConsumerHelper<Authors> _authorHelper;


        public CreateModel(IAuthorsRepository repo, IWebApiConsumerHelper<Authors> authorHelper)
        {
            _repo = repo;
            _authorHelper = authorHelper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Authors Authors { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MyBooks.Entity.Global.GlobalVariables.useWebApi)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Authors), Encoding.UTF8, "application/json");
                await _authorHelper.ConsumeWebApi("Authors", HttpMethod.Post,content);
            }
            else
            {
                await _repo.AddAuthors(Authors);

            }

            return RedirectToPage("./Index");
        }
    }
}
