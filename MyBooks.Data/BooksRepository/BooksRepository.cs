using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBooks.Entity.Books;

namespace MyBooks.Data.BooksRepository
{
   public class BooksRepository: IBooksRepository
    {
        private readonly MyBooksDBContext _context;
        public BooksRepository(MyBooksDBContext context)
        {
            this._context = context;
        }
        public async Task AddBooks(Books author)
        {
            _context.Books.Add(author);
            await Commit();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var author = await GetBooksById(id);
            _context.Books.Remove(author);
            await Commit();
        }

        public async Task<IList<Books>> GetBooks()
        {
            return await _context.Books.Include(x=>x.Authors).ToListAsync();
        }

        public async Task<Books> GetBooksById(int id)
        {
            return await _context.Books.Include(x=>x.Authors).FirstOrDefaultAsync(m => m.BookId == id);
        }

        public async Task<int> GetBooksCount()
        {
            return await _context.Books.CountAsync();

        }

        public async Task UpdateBooks(Books author)
        {
            _context.Attach(author).State = EntityState.Modified;
            await Commit();
        }
    }
}
