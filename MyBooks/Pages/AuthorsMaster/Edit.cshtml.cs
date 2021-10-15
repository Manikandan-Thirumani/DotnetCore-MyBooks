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
using Microsoft.EntityFrameworkCore;
using MyBooks.CommonHelpers;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;
using Newtonsoft.Json;

namespace MyBooks.Pages.AuthorsMaster
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly IAuthorsRepository _repo;
        private readonly IWebApiConsumerHelper<Authors> _authorHelper;


        public EditModel(IAuthorsRepository repo, IWebApiConsumerHelper<Authors> authorHelper)
        {
            _repo = repo;
            _authorHelper = authorHelper;
        }

        [BindProperty]
        public Authors Authors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (MyBooks.Entity.Global.GlobalVariables.useWebApi)
            {

                Authors = await _authorHelper.ConsumeWebApi($"Authors/{id}", HttpMethod.Get);
            }
            else
            {
                Authors = await _repo.GetAuthorsById((int)id);

            }

            if (Authors == null)
            {
                return NotFound();
            }
            return Page();
        }

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
                await _authorHelper.ConsumeWebApi($"Authors/{Authors.AuthorId}", HttpMethod.Put, content);
            }
            else
            {
                await _repo.UpdateAuthors(Authors);

            }

            return RedirectToPage("./Index");
        }

    }
}
