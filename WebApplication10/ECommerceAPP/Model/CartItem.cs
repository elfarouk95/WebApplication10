using System.Collections.Generic;

namespace WebApplication10.ECommerceAPP.Model
{
    public class CartItem
    {
        public int PId { get; set; }
        public int Qty { get; set; }
    }

    public class OrderDTO
    {
        public int customerId { get; set; }

        public List<CartItem> list { get; set; }
    }
}
