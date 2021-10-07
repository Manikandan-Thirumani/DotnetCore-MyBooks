using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Entity.Books;

namespace MyBooks.Data.BooksRepository
{
  public  interface IBooksRepository
    {
        Task<IList<Books>> GetBooks();
        Task AddBooks(Books author);
        Task<Books> GetBooksById(int id);
        Task DeleteBook(int id);
        Task UpdateBooks(Books author);
        Task<int> GetBooksCount();
        Task Commit();
    }
}
