using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBooks.Entity.Authors
{
  public  class Authors
    {
        [Required]
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Author Name")]
        public string AuthorName { get; set; }

        [ForeignKey("BookAuthorId")]
        public ICollection<Books.Books> Books { get; set; }
    }
}
