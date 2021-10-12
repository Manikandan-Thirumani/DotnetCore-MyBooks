using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;

namespace MyBooks.Pages.AuthorsMaster
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IAuthorsRepository _repo ;

        public CreateModel(IAuthorsRepository repo)
        {
            _repo = repo;
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
            await _repo.AddAuthors(Authors);

            return RedirectToPage("./Index");
        }
    }
}
