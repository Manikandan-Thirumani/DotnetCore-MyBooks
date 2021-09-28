using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;

namespace MyBooks.Pages.AuthorsMaster
{
    public class IndexModel : PageModel
    {
        private readonly IAuthorsRepository _repo;

        public IndexModel(IAuthorsRepository repo)
        {
            _repo = repo;
        }

        public IList<Authors> Authors { get;set; }

        public async Task OnGetAsync()
        {
            Authors = await _repo.GetAuthors();
        }
    }
}
