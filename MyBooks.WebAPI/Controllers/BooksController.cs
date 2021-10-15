using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooks.Data.BooksRepository;
using MyBooks.Entity.Books;

namespace MyBooks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _repo;

        public BooksController(IBooksRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetBooks()
        {
            return (await _repo.GetBooks()).ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBook(int id)
        {
            var book = await _repo.GetBooksById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Books>> PostBook(Books book)
        {
            await _repo.AddBooks(book);

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Books>> DeleteBook(int id)
        {
            var book = await _repo.GetBooksById(id);
            if (book == null)
            {
                return NotFound();
            }

          await  _repo.DeleteBook(id);

            return book;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Books book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }
            await _repo.UpdateBooks(book);

            return NoContent();
        }
    }
}
