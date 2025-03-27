using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderCLI;
using OrderCLI.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        private List<Good> goods;
        private OrderService service;

        [TestInitialize]
        public void init()
        {
            // 初始化一些商品
            Good apple = new Good("apple", 1.99);
            Good banana = new Good("banana", 2.99);
            Good cheeze = new Good("cheeze", 5.00);
            goods = new List<Good>();
            goods.Add(apple);
            goods.Add(banana);
            goods.Add(cheeze);

            // 模拟一个用户行为
            service = new OrderService("Tester");

            // 提交一个订单
            service.CreateOrder();
            service.AddGood(goods[0], 2);
            service.AddGood(goods[1], 3);
            service.CommitOrder();

            // 提交第二个订单
            service.CreateOrder();
            service.AddGood(goods[2], 5);
            service.CommitOrder();
        }

        [TestMethod()]
        public void SelectByGoodTest()
        {
            List<Order> res = OrderService.SelectByGood("cheeze");
            foreach (Order item in res)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod()]
        public void SortOrdersTest() {
            Console.WriteLine("自定义排序前: ");
            foreach (var item in OrderService.GetOrders()) { 
                Console.WriteLine(item);
            }
            Console.WriteLine("自定义排序后: ");
            OrderService.SortOrders((o1, o2) => 1);
            foreach (var item in OrderService.GetOrders()) {
                Console.WriteLine(item);
            }
        }
    }
}