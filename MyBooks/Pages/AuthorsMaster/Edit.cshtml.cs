using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;

namespace MyBooks.Pages.AuthorsMaster
{
    public class EditModel : PageModel
    {
        private readonly IAuthorsRepository _repo;

        public EditModel(IAuthorsRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Authors Authors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Authors =await _repo.GetAuthorsById((int)id);

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

           await _repo.UpdateAuthors(Authors);

            return RedirectToPage("./Index");
        }

    }
}
