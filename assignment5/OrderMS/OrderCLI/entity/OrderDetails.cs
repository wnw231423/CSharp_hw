using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.entity
{
    public class OrderDetails {
        private Dictionary<Good, int> Goods;
        private double TotalPrice;

        public OrderDetails() {
            Goods = new Dictionary<Good, int>();
            TotalPrice = 0;
        }

        public void AddGood(Good g, int n) {
            if (Goods.ContainsKey(g)) Goods[g] += n;
            else Goods[g] = n;
            TotalPrice += n * g.Price;
        }

        public void RemoveGood(Good g) {
            // TODO: 可能需要改进，移除多少数目，而不是全部移除
            Goods.Remove(g);
        }

        public Double GetTotalPrice() { return TotalPrice; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("订单明细:");
            foreach (KeyValuePair<Good, int> pair in Goods) {
                sb.Append($"\n  * {pair.Key}\tx{pair.Value}"); 
            }
            sb.Append($"\n  总价: {TotalPrice}");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Dictionary<Good, int>>.Default.Equals(Goods, details.Goods) &&
                   TotalPrice == details.TotalPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Goods, TotalPrice);
        }
    }
}
