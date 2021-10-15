using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBooks.CommonHelpers;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;

namespace MyBooks.Pages.AuthorsMaster
{
    [Authorize]

    public class DeleteModel : PageModel
    {
        private readonly IAuthorsRepository _repo;
        private readonly IWebApiConsumerHelper<Authors> _authorHelper;


        public DeleteModel(IAuthorsRepository repo, IWebApiConsumerHelper<Authors> authorHelper)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (MyBooks.Entity.Global.GlobalVariables.useWebApi)
            {

                Authors = await _authorHelper.ConsumeWebApi($"Authors/{id}", HttpMethod.Get);
                if (Authors != null)
                {
                    Authors = await _authorHelper.ConsumeWebApi($"Authors/{id}", HttpMethod.Delete);
                }
            }
            else
            {
                Authors = await _repo.GetAuthorsById((int)id);
                if (Authors != null)
                {
                    await _repo.DeletAuthor((int)id);
                }

            }
            

            return RedirectToPage("./Index");
        }
    }
}
