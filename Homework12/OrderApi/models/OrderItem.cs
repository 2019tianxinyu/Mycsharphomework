using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSys
{
    class OrderItem
    {
        [Key]
        public uint Index { get; set; } //序号

        public String GoodsName { get; set; }//商品名字

        public uint Quantity { get; set; }//数量

        public double unitPrice { get; set; }//单价

        public OrderItem() { }

        public OrderItem(uint i, String goodsName, double unitprice, uint quantity)
        {
            this.Index = i;
            this.GoodsName = goodsName;
            this.unitPrice = unitprice;
            this.Quantity = quantity;
        }

        public double sum
        {
            get { return unitPrice * Quantity; }
        }

        public override string ToString()
        {
            return $"[No.:{Index},goods:{GoodsName},quantity:{Quantity},totalPrice:{sum}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
