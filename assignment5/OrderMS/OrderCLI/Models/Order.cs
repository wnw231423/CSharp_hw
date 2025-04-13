using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    public int UserId { get; set; } // foreign key
    public User User { get; set; }
    public decimal TotalPrice
    {
        get => GetPrice();
    }

    public Order(){}
    
    public Order(List<OrderDetail> details, User user)
    {
        Details = details;
        User = user;
        UserId = user.Id;
    }

    public decimal GetPrice() { 
        decimal price = 0;
        foreach (OrderDetail detail in Details)
        {
            price += detail.GetPrice();
        }
        return price;
    }
}