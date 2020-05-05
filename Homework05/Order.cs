using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSys
{
    class Order: IComparable<Order>
    {
        public uint OrderId { get; set; }
         List<OrderItem> items = new List<OrderItem>();
        public String Customer { get; set; }
        public double sum
        {
            get { return sum; }
            set
            {
                foreach( OrderItem item in items)
                sum = sum + item.Quantity * item.unitPrice;
            }
        }
        public DateTime CreateTime { get; set; }
        public Order(uint i ,List<OrderItem> list)
        {
            this.OrderId = i;
            foreach(OrderItem item in list)
            {
                items.Add(item);

            }
        }
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"订单号:{OrderId}, 客户:{Customer},订单创建时间:{CreateTime},订单总价：{sum}");
            items.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }


        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.OrderId.CompareTo(other.OrderId);
        }
    }
}




