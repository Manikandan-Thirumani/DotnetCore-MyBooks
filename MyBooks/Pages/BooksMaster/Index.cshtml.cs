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
    public class IndexModel : PageModel
    {
        private readonly IBooksRepository _repo;

        public IndexModel(IBooksRepository repo)
        {
            _repo = repo;
        }

        public IList<Books> Books { get;set; }

        public async Task OnGetAsync()
        {
            Books = await _repo.GetBooks();
        }
    }
}
