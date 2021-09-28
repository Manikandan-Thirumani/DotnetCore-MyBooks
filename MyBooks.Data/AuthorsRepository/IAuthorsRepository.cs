using MyBooks.Entity.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Data.AuthorsRepository
{
   public interface IAuthorsRepository
    {
        Task<IList<Authors>> GetAuthors();
        Task AddAuthors(Authors author);
        Task<Authors> GetAuthorsById(int id);
        Task DeletAuthor(int id);
        Task UpdateAuthors(Authors author);
        Task Commit();




    }
}
