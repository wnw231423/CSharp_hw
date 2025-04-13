using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.Models;

public class OrderDetail
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int OrderId { get; set; } // foreign key
    public int GoodId { get; set; }
    public Good Good { get; set; }
    public int Quantity {  get; set; }

    public OrderDetail()
    {
    }

    public OrderDetail(int orderId, Good good, int quantity)
    {
        OrderId = orderId;
        Good = good;
        GoodId = good.Id;
        Quantity = quantity;
    }

    public decimal GetPrice() {
        return Good.Price;
    }

    public override string ToString()
    {
        string res = "";
        res += Good;
        res += " \t x";
        res += Quantity;
        return res;
    }

    public override bool Equals(object? obj)
    {
        return obj is OrderDetail detail &&
               Id == detail.Id &&
               GoodId == detail.GoodId &&
               EqualityComparer<Good>.Default.Equals(Good, detail.Good) &&
               Quantity == detail.Quantity;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, GoodId, Good, Quantity);
    }
}