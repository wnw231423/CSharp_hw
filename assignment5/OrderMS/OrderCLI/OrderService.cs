using OrderCLI.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
         * 3. 当用户使用时，会从TotalOrders中拉取一个副本，用户在副本中操作，最后结束时用户退出，
         *    CommitService再把副本的更新内容写回TotalOrders.
         */

        // 订单列表，存储所有的订单
        public static HashSet<Order> TotalOrders = new HashSet<Order>();

        // 一个OrderService实例只能服务一个用户
        private User User;
        private List<Order> Orders;
        private OrderDetails? CurrentOrderDetail;

        public OrderService(User user) { 
            this.User = user;
            if (User.IsAdmin)
            {
                Orders = TotalOrders.ToList();
            }
            else
            {
                Orders = TotalOrders.Where(o => o.Buyer.Equals(User)).ToList();
            }
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
            Orders.Add(orderToCommit);
            TotalOrders.Add(orderToCommit); // 维持一致性
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
            TotalOrders.Remove(undo);  // 维持一致性
            Orders.Remove(undo);
            CurrentOrderDetail = undo.Details;  // TODO: 再次提交订单后，订单ID将会改变。后面添加数据库之后，可能会涉及到ID方面的问题
        }

        public Order SelectById(int id) {
            var query = from order in Orders where order.Id == id orderby order.Details.GetTotalPrice() select order;
            var res = query.ToList();
            if (res.Count != 1)
            {
                throw new Exception("查找失败！");
            }
            //else if ((!res.First().Buyer.IsAdmin) && res.First().Buyer != User) {
            //    throw new Exception("该订单您无权查看！");
            //}
            return res.First();
        }

        public List<Order> SelectByUser(string user) {
            // This function could only be meaningful for admins
            var res = from order in Orders where order.Buyer.Name == user orderby order.Details.GetTotalPrice() select order;
            return res.ToList();
        }

        public List<Order> SelectByPrice(double min, double max) {
            var query = from order in Orders 
                      where order.Details.GetTotalPrice() >= min && order.Details.GetTotalPrice() <= max 
                      orderby order.Details.GetTotalPrice() 
                      select order;
            return query.ToList();
        }

        public List<Order> SelectByGood(string goodName)
        {
            var res = from order in Orders
                      where order.Details.ContainGood(goodName)
                      orderby order.Details.GetTotalPrice()
                      select order;
            return res.ToList();
        }

        public void SortOrders(Comparison<Order> sortFunc) {
            Orders.Sort(sortFunc);
        }

        public List<Order> GetOrders() { 
            return Orders;
        }

        public void ClearOrders() { 
            foreach (var order in Orders)
            {
                TotalOrders.Remove(order);  // 维持一致性
            }
            Orders = new List<Order>();
        }
    }
}
