using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystem01
{
    [Serializable]
     public  class OrderService
    {
        private  List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        public void AddOrder(string customerName)
        {
            //string customerName;
            Console.Write("请输入客户名：");
            customerName = Console.ReadLine();
            if (customerName == null) throw new Exception("客户名不能为空！");
            Customer customer = new Customer(customerName);


            bool IsRepeat = false;
            Order order;
            while (true)
            {
                order = new Order(customer);
                foreach (Order x in orderList)
                {
                    if (x.Equals(order)) IsRepeat = true;
                }
                if (!IsRepeat) break;
            }
            order.InputOrder();
            orderList.Add(order);//输入订单
            //确认订单信息
            Console.Write("\n你添加的订单是：\n");
            Console.Write(order);
        }

        public void ChangeByOrderId()
        {
            long OrderId;
            Console.Write("请输入你想修改的订单：");
            OrderId = long.Parse(Console.ReadLine());
            var result = orderList.Where(x => x.OrderId == OrderId);
            Order order = result.FirstOrDefault();
            if (order == null) throw new Exception("订单号异常！");
            else
            {
                Console.Write("\n原来的订单号是：\n");
                Console.Write(order);
                Console.Write("\n修改后的订单号是：\n");
                order.delete();
                order.InputOrder();
                Console.Write("\n现在的订单号是：\n");
                Console.Write(order);
            }
        }

        public void DeleteByOrderId()
        {
            Console.Write("\n你想要删除的订单号是：\n");
            long OrderId;
            OrderId = long.Parse(Console.ReadLine());
            var result = orderList.Where(x => x.OrderId == OrderId);
            Order order = result.FirstOrDefault();
            if (order == null) throw new Exception("订单号异常！");
            else
            {
                Console.Write("\n你想要删除的订单号是：\n");
                Console.Write(order);
                orderList.Remove(order);
            }
        }

        public void PrintOrders()
        {
            if (orderList.Count == 0)
                Console.Write("现在没有订单");
            else
            {
                Console.Write("现在的订单有：");
                int i = 0;
                foreach (var x in orderList)
                {
                    Console.Write("\n订单" + (i + 1) + "：\n");
                    Console.Write(x);
                    i++;
                }
            }
        }

        public void Search()
        {
            long OrderId;
            Console.WriteLine("请选择查询方式：1、按订单号查询 2、按货物名进行查询");
            string i =Console.ReadLine();
            switch (i)
            {
                case "1":
                    Console.Write("请输入想要查询的订单号：");
                    OrderId = long.Parse(Console.ReadLine());
                    var result = orderList.Where(x => x.OrderId == OrderId);
                    Order order = result.FirstOrDefault();
                    if (order == null) throw new Exception("订单号异常！");
                    else
                    {
                     Console.Write(order);
                     }
                    break;
                case "2":
                    Console.WriteLine("请输入想要查询的货物名称：");
                    break;

             
                    
            }
           

        }

        public void SortedByOrderId()
        {
            orderList.Sort((order1, order2) => (int)(order1.OrderId - order2.OrderId));
        }


        public void Export()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            String xmlFileName = "order.xml";
            using (FileStream fs= new FileStream(xmlFileName, FileMode.Create))
            {
                xmlser.Serialize(fs, orderList);
            }
            Console.WriteLine("\nSerialized as Xml:");
            Console.WriteLine(File.ReadAllText("order.xml"));
        }

        public void Import()
        {
            XmlSerializer xmlser2 = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
               List<Order> output=(List<Order>)xmlser2.Deserialize(fs);
                Console.WriteLine("\nDeserialized from order.Xml:");
                foreach(Order x in output)
                {
                    Console.WriteLine(x);
                }

            }
        }
    }
}
