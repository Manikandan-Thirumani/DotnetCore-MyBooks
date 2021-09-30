using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Data.BooksRepository;
using MyBooks.Entity.Books;

namespace MyBooks.Pages.BooksMaster
{
    public class DeleteModel : PageModel
    {
        private readonly IBooksRepository _repo;

        public DeleteModel(IBooksRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _repo.GetBooksById((int)id);

            if (Books == null)
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

            Books = await _repo.GetBooksById((int)id);

            if (Books != null)
            {
               await _repo.DeleteBook((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
