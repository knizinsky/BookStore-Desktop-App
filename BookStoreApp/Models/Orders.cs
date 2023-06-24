using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }
        public string orderType { get; set; }
        public DateTime expectedOrderDate { get; set; }

        public Book Book { get; set; }

        public Orders()
        {
            orderType= string.Empty;
            Book = new Book();
        }
    }
}
