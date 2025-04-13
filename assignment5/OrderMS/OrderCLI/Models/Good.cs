using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCLI.Models;

public class Good
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Good()
    {
    }

    public Good(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        string res = "";
        res += Name;
        res += "|";
        res += Price;
        return res;
    }

    public override bool Equals(object? obj)
    {
        return obj is Good good &&
               Id == good.Id &&
               Name == good.Name &&
               Price == good.Price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price);
    }
}
