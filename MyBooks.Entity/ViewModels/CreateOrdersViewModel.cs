using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBooks.Entity.ViewModels
{
    public class CreateOrdersViewModel
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string CustomerAddress { get; set; }

        public List<Books.Books> CartBooks { get; set; }
    }
}
