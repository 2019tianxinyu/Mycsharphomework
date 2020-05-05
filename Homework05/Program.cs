using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSys
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderList = new List<OrderItem>(new OrderItem[]
            {
                 orderService.SetOrderItem(1,"手电筒",10,20),
               orderService.SetOrderItem(2, "台灯", 20, 5),
                orderService.SetOrderItem(3,"电冰箱",1000,10),
             });

            orderService.AddOrder(1,orderList);
            orderService.AddOrder(2, orderList);
            orderService.AddOrder(3, orderList);
            orderService.QueryOrderById(1);
            orderService.QueryOrderById(2);
            orderService.QueryOrderById(3);



        }
    }
        }
