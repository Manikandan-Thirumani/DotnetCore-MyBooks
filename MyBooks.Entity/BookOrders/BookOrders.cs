using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBooks.Entity.BookOrders
{
   public class BookOrders
    {
        [Required]
        [Key]
        public int OrdersId { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string CustomerAddress { get; set; }

    }
}
