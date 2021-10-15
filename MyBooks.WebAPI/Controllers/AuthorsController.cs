using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using MyBooks.Data.AuthorsRepository;
using MyBooks.Entity.Authors;

namespace MyBooks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _repo;

        public AuthorsController(IAuthorsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<List<Authors>>> GetAuthors()
        {
            return (await _repo.GetAuthors()).ToList();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthor(int id)
        {
            var author = await _repo.GetAuthorsById(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Authors>> PostAuthor(Authors author)
        {
            await _repo.AddAuthors(author);

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Authors>> DeleteAuthor(int id)
        {
            var author = await _repo.GetAuthorsById(id);
            if (author == null)
            {
                return NotFound();
            }

        await  _repo.DeletAuthor(id);

            return author;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id,Authors author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }
            await _repo.UpdateAuthors(author);

            return NoContent();
        }
        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<int>> GetOrdersCount()
        {
            return await _repo.AuthorsCount();
        }
    }
}
