using System.Collections.Generic;

namespace WebApplication10.ECommerceAPP.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<OrderItem> orders { get; set; }
    }
}
