using System.Collections.Generic;

namespace WebApplication10.ECommerceAPP.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<OrderItem> items { get; set; }

    }
}
