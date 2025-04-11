using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }

    public User()
    {
    }

    public User(string name, bool isAdmin)
    {
        Name = name;
        IsAdmin = isAdmin;
    }

    public override string ToString()
    {
        string res = IsAdmin ? "*" : "";
        res += Name;
        return res;
    }

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               Id == user.Id &&
               Name == user.Name &&
               IsAdmin == user.IsAdmin;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, IsAdmin);
    }
}