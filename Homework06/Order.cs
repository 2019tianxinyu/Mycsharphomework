using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem01
{
   public class Order : IComparable
    {
        private Customer customer;
        public long OrderId { get; set; }
        public DateTime orderTime;
        private List<OrderItem> orderItemsList;

        public Order(Customer customer)
        {

            orderTime = DateTime.Now;
            orderItemsList = new List<OrderItem>();
            //随机生成单号
            long num = 0;
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                num += random.Next(10) * (long)Math.Pow(10, i);
            }
            OrderId = num;
        }

        public void AddItem(OrderItem orderItem)
        {
            bool IsRepeat = false;
            foreach (OrderItem x in orderItemsList)
            {
                if (x.Equals(orderItem)) IsRepeat = true;
            }

            if (!IsRepeat)
            {
                orderItemsList.Add(orderItem);
                orderTime = DateTime.Now;
            }
            else throw new Exception("OrderItem repeats");

        }

        public void InputOrder()
        {
            Console.Write("请输入订单ID：");
            int orderItemId = int.Parse(Console.ReadLine());
            if (orderItemId < 0) throw new Exception("订单ID异常，请重新确认订单ID！");
            else
            {
                for (int i = 0; i < orderItemId; i++)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.InputItem(i);
                    AddItem(orderItem);
                    Console.Write('\n');
                }
            }
        }
        public void ChangeItem(OrderItem olditem, OrderItem newitem)
        {
            var item = orderItemsList.Where(x => x.Equals(olditem)).FirstOrDefault();
            if (item != null)
                item.Change(newitem);
            else throw new Exception();
        }

        public void delete()
        {
            orderItemsList.Clear();

        }

        public double TotalSum()
        {
            double sum = 0;
            foreach (OrderItem x in orderItemsList)
            {
                sum += x.sum();
            }
            return sum;

        }

        public int CompareTo(Object obj)
        {
            Order order = obj as Order;
            if (TotalSum() - order.TotalSum() > 0) return 1;
            else if (TotalSum() - order.TotalSum() < 0) return -1;
            else return 0;
        }

        public override string ToString()
        {
            string str = "订单ID" + OrderId + customer.ToString();
            int i = 1;
            foreach (OrderItem x in orderItemsList)
            {
                str += "订单" + i + "：\n";
                str += x.ToString();
                i++;

            }
            return "订单时间：" + orderTime.ToString("yyyy-mm-dd hh:mm:ss") + str + "订单总计：" + TotalSum();
        }
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order.OrderId == OrderId;
        }

        public override int GetHashCode()
        {
            var hashCode = 678080838;
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + orderTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(orderItemsList);
            return hashCode;
        }
    }
}
