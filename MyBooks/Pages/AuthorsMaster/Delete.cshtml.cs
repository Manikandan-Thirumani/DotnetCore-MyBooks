﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly IAuthorsRepository _repo;

        public DeleteModel(IAuthorsRepository repo)
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

            Authors = await _repo.GetAuthorsById((int)id);

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

            Authors = await _repo.GetAuthorsById((int)id); 

            if (Authors != null)
            {
              await  _repo.DeletAuthor((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}