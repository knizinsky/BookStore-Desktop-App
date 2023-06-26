using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp
{
    /// <summary>
    /// Represents orders of books.
    /// </summary>
    public class Orders
    {
        [Key]
        public int orderId { get; set; }
        public string orderType { get; set; }
        public DateTime expectedOrderDate { get; set; }

        [ForeignKey("Book")]
        public int bookId { get; set; }

        public Book Book { get; set; }

        public Orders()
        {
            orderType= string.Empty;
        }

        public void GenerateExpectedOrderDate()
        {
            var random = new Random();
            int days = random.Next(2, 10);
            expectedOrderDate = DateTime.Now.AddDays(days);
        }
    }
}
