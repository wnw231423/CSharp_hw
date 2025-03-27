using OrderCLI.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI
{
    /* 订单业务类
     * 用户应当遵循以下业务流程：
     *     1. 使用CreateOrderDetail来创建一个订单
     *     2. 使用AddGood,RemoveGood来订单中添加或者删除一个或者多个商品
     *     3. 使用CommitOrder来确认并提交订单，订单会保存到系统中，订单中的元数据以提交时为准
     *     4. 使用UndoOrder来撤回已提交订单，从而继续修改
     *     4. 可以使用各个"SelectBy___"来查询订单
     */
    public class OrderService {
        /* Implementation Doc
         * 1. 整体实现思路类似于git，可以add和rm商品，只有在最后提交时才会进行“重复检查”
         * 2. 缺点，在提交一个订单之前不能创建并处理第二个订单，必须把当前订单提交后才能处理第二个订单
         */

        // 订单列表，存储所有的订单
        private static List<Order> Orders = new List<Order>();

        // 一个OrderService实例只能服务一个用户
        private string User {  get; set; }
        private OrderDetails? CurrentOrderDetail;

        public OrderService(string user) { 
            this.User = user;
        }

        public void CreateOrder() { 
            CurrentOrderDetail = new OrderDetails();
        }

        public void AddGood(Good g, int n) {
            if (CurrentOrderDetail == null) {
                throw new Exception("需要先创建订单！");
            }
            CurrentOrderDetail.AddGood(g, n);
        }

        public void RemoveGood(Good g) {
            if (CurrentOrderDetail == null) {
                throw new Exception("需要先创建订单！");
            }
            CurrentOrderDetail.RemoveGood(g);
        }

        public void CommitOrder() {
            if (CurrentOrderDetail == null) {
                throw new Exception("需要先创建订单！");
            }
            Order orderToCommit = new Order(User, DateTime.Now, CurrentOrderDetail);
            foreach (var order in Orders) {
                if (order.Equals(orderToCommit)) {
                    throw new Exception("订单重复！");
                }
            }
            CurrentOrderDetail = null;
        }

        public void UndoOrder(int id) {
            var undo = Orders.Find(order => order.Id == id);
            if (undo == null) {
                throw new Exception("该订单号不存在！");
            }
            if (undo.Buyer != User) {
                throw new Exception("该订单您无权修改！");
            }
            CurrentOrderDetail = undo.Details;  // TODO: 再次提交订单后，订单ID将会改变。后面添加数据库之后，可能会涉及到ID方面的问题
        }

        public static List<Order> SelectById(int id)
        {
            var res = from order in Orders where order.Id == id orderby order.Details.GetTotalPrice() select order;
            return (List<Order>)res;
        }

        public static List<Order> SelectByUser(string user) {
            var res = from order in Orders where order.Buyer == user orderby order.Details.GetTotalPrice() select order;
            return (List<Order>)res;
        }

        public static List<Order> SelectByPrice(double min, double max)
        {
            var res = from order in Orders 
                      where order.Details.GetTotalPrice() >= min && order.Details.GetTotalPrice() <= max 
                      orderby order.Details.GetTotalPrice() 
                      select order;
            return (List<Order>)res;
        }

        public static List<Order> SelectByGood(string goodName)
        {
            var res = from order in Orders
                      where order.Details.ContainGood(goodName)
                      orderby order.Details.GetTotalPrice()
                      select order;
            return (List<Order>)res;
        }

        public static void SortOrders(Comparison<Order> sortFunc) {
            //TODO: need test.
            Orders.Sort(sortFunc);
        }

        public static List<Order> GetOrders() { 
            return Orders;
        }
    }
}
