using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem01;

namespace UnitTestOrderService
{
    [TestClass]
    public class UnitTest1
    {
        public OrderSystem01.OrderService testservice = new OrderSystem01.OrderService();
        List<Order> orderlist = new List<Order>();
        [TestMethod]
        public void AddOrder()
        {
            testservice.AddOrder("张三");
            Customer customer = "张三";
            Order order = new Order("张三");
            order.InputOrder();
            orderlist.Add(order);
            Console.Write(order);
        }
        [TestMethod]
        public void ChangeByOrderIdTset()
        {
            long OrderId = 1;
            var result = orderlist.Where(x => x.OrderId == OrderId);
            Order order = result.FirstOrDefault();
            order.delete();
            order.InputOrder();
            Console.Write(order);
        }

        [TestMethod]
        public void DeleteByOrderId()
        {
            long OrderId = 2;
            var result = orderlist.Where(x => x.OrderId == OrderId);
            Order order = result.FirstOrDefault();
            Console.Write(order);
            orderlist.Remove(order);

        }

        [TestMethod]
        public void PrintOrders()
        {
            if (orderlist.Count != 0)
            {
                int i = 0;
                foreach (var x in orderlist)
                {
                    Console.Write("\n订单" + (i + 1) + "：\n");
                    Console.Write(x);
                    i++;
                    Console.WriteLine();
                }
            }
        }
        [TestMethod]
        public void SearchTest()
        {
            long OrderId = 1;
            var result = orderlist.Where(x => x.OrderId == OrderId);
            Order order = result.FirstOrDefault();
            Console.Write(order);
            
        }
       

    }
}
