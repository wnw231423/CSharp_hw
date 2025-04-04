﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.entity
{
    public class Order {
        private static int _id = 1;
        public int Id { get; set; }
        public User Buyer { get; set; }
        public DateTime Date { get; set; }
        public OrderDetails Details;

        public Order(User Buyer, DateTime date, OrderDetails d) {
            this.Buyer = Buyer;
            this.Date = date;
            this.Details = d;
            this.Id = _id++;
        }

        public OrderDetails GetOrderDetails() { return this.Details; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("***订单信息***\n");
            sb.Append($"订单号:\t{Id}\n");
            sb.Append($"创建者:\t{Buyer.Name}\n");
            sb.Append($"创建时间:\t{Date}\n");
            sb.Append($"{Details}");

            return sb.ToString();
        }

        // 当订单的创建者和订单明细相同时，则认为订单重复
        public override bool Equals(object? obj) {
            return obj is Order order &&
                   Buyer == order.Buyer &&
                   Details.Equals(order.GetOrderDetails());
        }

        public override int GetHashCode() {
            return HashCode.Combine(Buyer, Details);
        }
    }
}
