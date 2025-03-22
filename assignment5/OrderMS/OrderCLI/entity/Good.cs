using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.entity
{
    // 商品类
    public class Good
    {
        public string Name { get; set; }
        public double Price {  get; set; }

        public Good(string name, double price) {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString() {
            return $"<{Name}: {Price}元>";
        }

        public override bool Equals(object? obj)
        {
            return obj is Good good &&
                   Name == good.Name &&
                   Price == good.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}
