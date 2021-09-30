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
    public class DetailsModel : PageModel
    {
        private readonly IBooksRepository _repo;

        public DetailsModel(IBooksRepository repo)
        {
            _repo = repo;
        }

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
    }
}
