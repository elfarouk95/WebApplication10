using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication10.ECommerceAPP.Model;

namespace WebApplication10.ECommerceAPP
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        List<Order> orders = new List<Order>();
        List<OrderItem> ordersItems = new List<OrderItem>();



        [HttpPost("CreateOrder")]
        public ActionResult addOrder(OrderDTO o)
        {
            Order or = new Order();
            or.CustomerId = o.customerId;
            or.date = DateTime.Now;
            
            orders.Add(or);
            // save

            foreach (var item in o.list)
            {
                OrderItem u = new OrderItem();
                u.prodId = item.PId;
                u.qty = item.Qty;
                u.orderId = or.Id;
                

                ordersItems.Add(u);

            }
            //save 

            return Ok("done");
        }
    }
}
