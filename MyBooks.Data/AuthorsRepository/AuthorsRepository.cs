using Microsoft.EntityFrameworkCore;
using MyBooks.Entity.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Data.AuthorsRepository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly MyBooksDBContext _context;
        public AuthorsRepository(MyBooksDBContext context)
        {
            this._context = context;
        }
        public async Task AddAuthors(Authors author)
        {
            _context.Authors.Add(author);
            await Commit();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeletAuthor(int id)
        {
            var author = await GetAuthorsById(id);
            _context.Authors.Remove(author);
            await Commit();
        }

        public async Task<IList<Authors>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();   
        }

        public async Task<Authors> GetAuthorsById(int id)
        {
         return   await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);
        }

        public async Task UpdateAuthors(Authors author)
        {
            _context.Attach(author).State = EntityState.Modified;
            await Commit();
        }
    }
}
