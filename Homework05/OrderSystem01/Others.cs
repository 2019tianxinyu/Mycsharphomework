using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem01
{
    class Customer
    {
        public string name;
        public string Name
        {
            get;
        }
        public Customer(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            if (name != null)
            {
                return "用户名：" + name + '\n';
            }
            else return "\n";
        }
    }

    internal class Goods
    {
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }
        public int GoodsNum { get; set; }
        public Goods(string goodsName, double goodsprice, int goodsNum)
        {
            GoodsName = goodsName;
            GoodsPrice = goodsprice;
            GoodsNum = goodsNum;
        }
        public double Pricetotal()
        {
            return GoodsPrice * GoodsNum;
        }
        public override string ToString()
        {

            return "商品名：" + GoodsName + "商品价格：" + GoodsPrice + "商品数量是：" + GoodsNum + "总价是：" + Pricetotal() + '\n';
        }
        public override bool Equals(object obj)
        {
            Goods goods = (Goods)obj;

            return goods.GoodsName == GoodsName && goods != null;

        }

        public override int GetHashCode()
        {
            var hashCode = 1106536047;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + GoodsPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + GoodsNum.GetHashCode();
            return hashCode;
        }
    }
}
