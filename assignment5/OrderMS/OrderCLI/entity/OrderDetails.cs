using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.entity
{
    public class OrderDetails {
        public Dictionary<Good, int> Goods { get; }
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

        public bool ContainGood(string goodName) { 
            //required by OrderService.SelectByGood
            return Goods.Any(g => g.Key.Name == goodName);
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
                sb.Append($"\n  * {pair.Key}\t x{pair.Value}"); 
            }
            sb.Append($"\n  总价: {TotalPrice.ToString("0.00")}");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is OrderDetails)) return false;
            var details = (OrderDetails)obj;

            if (Goods.Count != details.Goods.Count) return false;

            foreach (var kv in Goods) {
                if (!details.Goods.TryGetValue(kv.Key, out int num) || num != kv.Value) {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Goods, TotalPrice);
        }
    }
}
