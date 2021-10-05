using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyBooks.Entity.Authors;

namespace MyBooks.Entity.Books
{
   public  class Books
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        public int BookAuthorId { get; set; }

        public Authors.Authors Authors { get; set; }

 
    }
}
