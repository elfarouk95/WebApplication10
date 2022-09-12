using System;
using System.Collections.Generic;

namespace WebApplication10.ECommerceAPP.Model
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime date { get; set; }


        public ICollection<OrderItem> items { get; set; }
    }
}
