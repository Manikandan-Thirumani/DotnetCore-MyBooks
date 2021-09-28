using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBooks.Entity.Books
{
   public  class Books
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BookName { get; set; }
        public decimal Price { get; set; }

        [Required]
        public int BookAuthorId { get; set; }
    }
}
