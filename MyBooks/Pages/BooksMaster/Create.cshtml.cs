using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Data.BooksRepository;
using MyBooks.Entity.Books;

namespace MyBooks.Pages.BooksMaster
{
    public class CreateModel : PageModel
    {
        private readonly IBooksRepository _booksrepo;
        private readonly IAuthorsRepository _authorsrepo;

        public List<SelectListItem> Authors { get; set; }


        public CreateModel(IBooksRepository booksrepo, IAuthorsRepository authorsrepo)
        {
            _booksrepo = booksrepo;
            _authorsrepo = authorsrepo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Authors =(await _authorsrepo.GetAuthors()).Select(a =>
                new SelectListItem
                {
                    Value = a.AuthorId.ToString(),
                    Text = a.AuthorName
                }).ToList();
            return Page();
        }

        [BindProperty]
        public Books Books { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          await _booksrepo.AddBooks(Books);

            return RedirectToPage("./Index");
        }
    }
}
