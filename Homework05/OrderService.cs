using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSys
{
    class OrderService
    {
         List<Order> orders =new List<Order>();
        
        public OrderService()
        {
            orders = new List<Order>();
        }

        public List<Order> Orders
        {
            get
            { return orders; }
        }
        
        public OrderItem SetOrderItem(uint i, string g,double u,uint q)
        {
            return new OrderItem(i, g, u, q);
        }
        public void AddOrder(uint OrderId,List <OrderItem> list)
        {
            Order temp = new Order(OrderId, list);
            //if (temp.OrderId.Equals(OrderId))
              //  throw new Exception($" {OrderId} 已经存在!");

            orders.Add(temp);
        }

        public void RemoveOrder(uint orderId)
        {
            Order order = GetOrder(orderId);
            if (order != null)
            {
                orders.Remove(order);
            }
           // else
            //{
             //   throw new ApplicationException($" {order}不存在!");
            //}
        }
        //根据id获取订单
        public Order GetOrder(uint id)
        {
            return orders.Where(n => n.OrderId == id).FirstOrDefault();
        }
        //查询订单
        public void QueryOrderById(int id)
        {
            var query = from order in orders
                        where order.OrderId == id
                        orderby order.sum
                        select order;
            foreach (var q in query)
            {
                Console.WriteLine(q);
            }



        }
     
        public void UpdateOrder(Order newOrder)
        {
            Order oldOrder = GetOrder(newOrder.OrderId);
            if (oldOrder == null)
                throw new ApplicationException($"{newOrder.OrderId} 不存在!");
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }

        public void Sort()
        {
            orders.Sort();
        }

        public void Sort(Func<Order, Order, int> func)
        {
            Orders.Sort((o1, o2) => func(o1, o2));
        }

     
    }
}
