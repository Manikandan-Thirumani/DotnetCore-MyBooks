using Microsoft.EntityFrameworkCore;
using MyBooks.Entity.Authors;
using MyBooks.Entity.BookOrders;
using MyBooks.Entity.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks.Data
{
  public  class MyBooksDBContext:DbContext
    {
        public MyBooksDBContext(DbContextOptions<MyBooksDBContext> options):base(options)
        {   }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        public DbSet<BookOrders> BookOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<BookOrders>().HasNoKey();
        }

    }
}
