using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem01
{
    class OrderItem : IComparable
    {
        private Goods goods;
        public OrderItem(string goodsName, double goodsPrice, int goodsNum)
        {
            goods = new Goods(goodsName, goodsPrice, goodsNum);
        }
        public OrderItem() { }
        public void Change(OrderItem orderItem)
        {
            goods = orderItem.goods;
        }

        public double sum()
        {
            return goods.Pricetotal();
        }

        public void InputItem(int i)
        {
            Goods goods;
            string goodsName;
            double goodsPrice;
            int goodsNum;
            Console.Write("请输入第" + (i + 1) + "个商品的名字：");
            goodsName = Console.ReadLine();
            Console.Write("请输入第" + (i + 1) + "个商品的单价：");
            goodsPrice = double.Parse(Console.ReadLine());
            Console.Write("请输入第" + (i + 1) + "个商品的数量：");
            goodsNum = int.Parse(Console.ReadLine());
            goods = new Goods(goodsName, goodsPrice, goodsNum);
        }

        public int CompareTo(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            if (goods.Pricetotal() - orderItem.goods.Pricetotal() > 0) return 1;
            else if (goods.Pricetotal() - orderItem.goods.Pricetotal() < 0) return -1;
            else return 0;
        }

        public override bool Equals(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            return base.Equals(orderItem.goods);
        }

        public override string ToString()
        {
            return goods.ToString();
        }

        public override int GetHashCode()
        {
            return -1930756903 + EqualityComparer<Goods>.Default.GetHashCode(goods);
        }
    }
}
