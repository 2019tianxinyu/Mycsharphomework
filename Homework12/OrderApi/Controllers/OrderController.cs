using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrderController(OrderContext context)
        {
            this.orderDB = context;
        }

        private IQueryable<Order> AllOrders()
        {
            IQueryable<Order> query = orderDB.Orders;
            return query.Include(o=>o.Customer).Include(o=>o.Items).ThenInclude(item =>item.GoodsItem);
        }

        [HttpGet("orderList")]
        public ActionResult<List<Order>> GetOrderList()
        {
            return AllOrders().ToList();
        }

        [HttpGet("searchId")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = AllOrders().FirstOrDefault(t => t.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost("addOrder")]
        public ActionResult<Order> AddOrder(Order order)
        {
            List<OrderItem> item = orderDB.OrderItems.ToList();
            List<Goods> goods = orderDB.GoodItems.ToList();
            List<Customer> customers = orderDB.Customers.ToList();
            try
            {
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return order;
        }

        [HttpDelete("removeOrder")]
        public ActionResult RemoveOrder(string id)
        {
            try
            {
                var order = orderDB.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDB.Remove(order);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }


        [HttpPut("updateOrder")]
        public ActionResult<Order> UpdateOrder(string id, Order order)
        {
            var oldItems = orderDB.OrderItems.Where(item => item.OrderId == id);
            orderDB.OrderItems.RemoveRange(oldItems);
            orderDB.SaveChanges();

            if (id != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDB.Entry(order).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpGet("searchGoodsName")]
        public ActionResult<List<Order>> QueryOrdersByGoodsName(string goodsName)
        {

            var query = AllOrders().Where(o => o.Items.Count(i => i.GoodsItem.Name == goodsName) > 0);
            return query.ToList();
        }

        [HttpGet("searchCustomerName")]
        public ActionResult<List<Order>> QueryOrdersByCustomerName(string customerName)
        {

            var query = AllOrders().Where(o => o.Customer.Name == customerName);
            return query.ToList();


        }

        [HttpGet("searchTotalAmount")]
        public ActionResult<List<Order>> QueryByTotalAmount(float amout)
        {
            return AllOrders()
            .Where(o => o.Items.Sum(item => item.GoodsItem.Price * item.Quantity) > amout).ToList();
        }
    }
}
