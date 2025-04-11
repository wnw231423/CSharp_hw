using Microsoft.EntityFrameworkCore;
using OrderCLI.Models;

namespace OrderCLI.Services;

public class OrderService
{
    public OrderService()
    {
        using var ctx = new OrderContext();
        if (ctx.Goods.Count() == 0)
        {
            ctx.Goods.Add(new Good("Apple", 9.9m));
            ctx.Goods.Add(new Good("Banana", 5.5m));
        }

        if (ctx.Users.Count() == 0)
        {
            ctx.Users.Add(new User("Alice", true));
            ctx.Users.Add(new User("Bob", false));
        }
    }

    public List<Order> GetOrders()
    {
        using var ctx = new OrderContext();
        return ctx.Orders
            .Include(o => o.Details)
            .ThenInclude(d => d.Good)
            .ToList();
    }

    public Order SelectOrderById(int id)
    {
        using var ctx = new OrderContext();
        var res = ctx.Orders
            .Include(o => o.Details).ThenInclude(d => d.Good)
            .Include(o => o.User)
            .SingleOrDefault(o => o.Id == id);
        if (res == null)
        {
            throw new InvalidOperationException("No order found");
        }
        return res;
    }

    public void AddOrder(Order order)
    {
        using var ctx = new OrderContext();
        ctx.Entry(order.User).State = EntityState.Unchanged;
        foreach (var detail in order.Details)
        {
            ctx.Entry(detail).State = EntityState.Unchanged;
        }
            
        ctx.Orders.Add(order);
        ctx.SaveChanges();
    }

    public void RemoveOrder(int id)
    {
        using var ctx = new OrderContext();
        var order = SelectOrderById(id);
        ctx.OrderDetails.RemoveRange(order.Details);
        ctx.Orders.Remove(order);
        ctx.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        RemoveOrder(order.Id);
        AddOrder(order);
    }

    public List<Order> SelectOrderByGoodName(string name)
    {
        using var ctx = new OrderContext();
        return ctx.Orders
            .Include(o => o.Details).ThenInclude(d => d.Good)
            .Include(o => o.User)
            .Where(o => o.Details.Any(d => d.Good.Name == name))
            .ToList();
    }

    public List<Order> SelectOrderByUserName(string name)
    {
        using var ctx = new OrderContext();
        return ctx.Orders
            .Include(o => o.Details).ThenInclude(d => d.Good)
            .Include(o => o.User)
            .Where(o => o.User.Name == name)
            .ToList();
    }

    public List<Order> SelectOrderByPrice(decimal min, decimal max)
    {
        using var ctx = new OrderContext();
        return ctx.Orders
            .Include(o => o.Details).ThenInclude(d => d.Good)
            .Include(o => o.User)
            .Where(o => min <= o.GetPrice() && o.GetPrice() <= max)
            .ToList();
    }
}